using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OData.ModelBuilder;
using PrestigePathway.Data.Abstractions;
using PrestigePathway.Data.Services;
using PrestigePathway.DataAccessLayer;
using PrestigePathway.DataAccessLayer.Abstractions;
using PrestigePathway.DataAccessLayer.Repositories;
using System.Text;
using FluentValidation;
using FluentValidation.AspNetCore;
using PrestigePathway.Api.Extensions;
using Microsoft.OpenApi.Models;
using PrestigePathway.Api.Infrastructure;
using PrestigePathway.Data.Validators;
using PrestigePathway.Data.Utilities;
using System.Text.Json;
using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Authorization;

namespace PrestigePathway.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // JWT Authentication Setup
            var jwtSettings = builder.Configuration.GetSection("Jwt");

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"])),
                    ClockSkew = TimeSpan.Zero 
                };
            });

            builder.Services.AddAuthorization(options =>
            {
                using (var scope = builder.Services.BuildServiceProvider().CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<SocialServicesDbContext>();
                    var permissions = dbContext.Permissions.Select(p => p.Name).ToList(); // Fetch permissions from DB

                    foreach (var permission in permissions)
                    {
                        options.AddPolicy(permission, policy => policy.Requirements.Add(new PermissionRequirement(permission)));
                    }
                }
            });

            // Configure CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigins", policy =>
                {
                    var allowedOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>();
                    policy.WithOrigins(allowedOrigins ?? Array.Empty<string>()) 
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials();
                });
            });
            
            var modelBuilder = new ODataConventionModelBuilder();
            // Add Controllers with OData Support
            builder.Services.AddControllers()
                .AddOData(options => options
                    .EnableQueryFeatures()
                    .Select().Expand().Filter().OrderBy()
                    .Count().SetMaxTop(100)
                    .AddRouteComponents("odata", modelBuilder.AddPrestigePathwayEdmModel()))
                .AddJsonOptions(options =>
                {
                    // Ignore case when comparing property names
                    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;

                    // Preserve references to prevent cycles
                    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;

                    // Use camel case for property names in the response
                    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                });

            builder.Services.AddDbContext<SocialServicesDbContext>(option =>
                option.UseSqlServer(builder.Configuration.GetConnectionString("PrestigePathConnection")));

            // Scrutor
            // builder.Services.Scan(scan => scan
            //     .FromAssemblies(Assembly.GetExecutingAssembly())
            //     .AddClasses(classes => classes.AssignableTo(typeof(IService<,>))).AsImplementedInterfaces().WithScopedLifetime()
            //     .AddClasses(classes => classes.AssignableTo(typeof(IRepository<>))).AsImplementedInterfaces().WithScopedLifetime()
            //     .AddClasses(classes => classes.AssignableTo(typeof(IValidator<>))).AsImplementedInterfaces().WithScopedLifetime()
            // );
            
            //Register services
            builder.Services.AddScoped(typeof(IService<,>), typeof(BaseService<,>));
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            // Configure FluentValidation
            builder.Services.AddValidatorsFromAssemblyContaining<UserValidator>();
            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddScoped<IValidator<ChangePasswordRequest>, ChangePasswordRequestValidator>();
            builder.Services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();
            
            // Add Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PrestigePathway.Api", Version = "v1" });
                c.OperationFilter<ODataSwaggerOperationFilter>(); // Register OData operation filter
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: 'Bearer {token}'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                 Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
            });

            builder.Services.AddMemoryCache();
            builder.Services.Configure<IpRateLimitOptions>(builder.Configuration.GetSection("IpRateLimiting"));
            builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            builder.Services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();
            builder.Services.AddInMemoryRateLimiting();

            var app = builder.Build();

            // Configure Middleware Pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.RoutePrefix = "docs";
                });

                app.Use(async (context, next) =>
                {
                    if (context.Request.Path.StartsWithSegments("/swagger") &&
                        !context.User.Identity.IsAuthenticated)
                    {
                        context.Response.StatusCode = 401;
                        await context.Response.WriteAsync("Unathorized access to Swagger");
                        return;
                    }

                    await next();
                });
            }
            
            app.UseHttpsRedirection();

            app.UseRouting();

            // Enable CORS
            app.UseCors("AllowSpecificOrigins");

            //app.UseMiddleware<CustomAuthorizationMiddleware>();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
