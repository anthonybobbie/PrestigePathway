using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OData.ModelBuilder;
using PrestigePathway.Data.Abstractions;
using PrestigePathway.Data.Services;
using PrestigePathway.DataAccessLayer;
using PrestigePathway.DataAccessLayer.Abstractions;
using PrestigePathway.DataAccessLayer.Models;
using PrestigePathway.DataAccessLayer.Repositories;
using System.Security.Claims;
using System.Text;
using FluentValidation;
using FluentValidation.AspNetCore;
using PrestigePathway.Api.Extensions;
using System.Reflection.Emit;
using Microsoft.OpenApi.Models;
using PrestigePathway.Api.Infrastructure;

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
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]))
                };
            });

            builder.Services.AddAuthorization();

            // Configure CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigins", policy =>
                {
                    policy.WithOrigins("http://localhost:3000", "http://localhost:5173") // Replace with your frontend URL
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials();
                });
            });
            var modelBuilder = new ODataConventionModelBuilder();
            // Add Controllers with OData Support
            builder.Services.AddControllers()
                .AddOData(options => options
                    .EnableQueryFeatures().Count()
                    .AddRouteComponents("odata", modelBuilder.AddPrestigePathwayEdmModel()))
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
                });

            builder.Services.AddDbContext<SocialServicesDbContext>(option =>
                option.UseSqlServer(builder.Configuration.GetConnectionString("PrestigePathConnection")));

            //Register services
            builder.Services.AddScoped(typeof(IService<,>), typeof(BaseService<,>));
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped<IAuthService, AuthService>();

            // Configure FluentValidation
            builder.Services.AddValidatorsFromAssemblyContaining<UserValidator>();
            builder.Services.AddFluentValidationAutoValidation();

            // Add Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PrestigePathway.Api", Version = "v1" });
                c.OperationFilter<ODataSwaggerOperationFilter>(); // Register OData operation filter

            });

            var app = builder.Build();

            // Configure Middleware Pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
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
