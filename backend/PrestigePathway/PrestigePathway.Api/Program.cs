using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PrestigePathway.BusinessLogicLayer.Services;
using PrestigePathway.DataAccessLayer;
using PrestigePathway.DataAccessLayer.Repositories;
using System.Text;
using PrestigePathway.DataAccessLayer.Abstractions.RepositoryAbstractions;
using PrestigePathway.DataAccessLayer.Abstractions.ServiceAbstractions;
using PrestigePathway.BusinessLogicLayer.Abstractions.ServiceAbstractions;
using PrestigePathway.Services;
using PrestigePathway.DataAccessLayer.Services;
using FluentValidation;
using PrestigePathway.DataAccessLayer.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using PrestigePathway.DataAccessLayer.Abstractions.ServicesAbstractions;
using PrestigePathway.BusinessLogicLayer.Abstractions;
using Microsoft.OpenApi.Models;

namespace PrestigePathway.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // jwt
            var jwtSettings = builder.Configuration.GetSection("Jwt");

            // Add authentication
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
           .AddJwtBearer(options =>
            {
                if (builder.Environment.IsDevelopment())
                {
                    // In development, bypass the usual token validation logic
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

                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            return Task.CompletedTask; // To observe if there are still issues
                        },
                        OnTokenValidated = context =>
                        {
                            // Optional: Add a fake claim or identity if needed
                            var claimsIdentity = new ClaimsIdentity(new Claim[]
                            {
                                new Claim(ClaimTypes.NameIdentifier, "user_id"),
                                new Claim(ClaimTypes.Name, "Developer")
                            });
                            context.Principal.AddIdentity(claimsIdentity);
                            return Task.CompletedTask;
                        },
                        OnChallenge = context =>
                        {
                            // Prevent the default behavior of returning a 401
                            context.HandleResponse();
                            return Task.CompletedTask;
                        }
                    };
                }
                else
                {
                    // In production, enforce strict validation
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
                }
            });

            builder.Services.AddAuthorization();

            // Add CORS services
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

            builder.Services.AddControllers();

            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = false;
            });

            builder.Services.AddDbContext<SocialServicesDbContext>(option =>
                option.UseSqlServer(builder.Configuration.GetConnectionString("PrestigePathConnection")));

            // Repositories
            builder.Services.AddScoped<IBookingRepository, BookingRepository>();
            builder.Services.AddScoped<IClientRepository, ClientRepository>();
            builder.Services.AddScoped<ILocationRepository, LocationRepository>();
            builder.Services.AddScoped<IPartnerRepository, PartnerRepository>();
            builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
            builder.Services.AddScoped<IPromotionRepository, PromotionRepository>();
            builder.Services.AddScoped<IServiceRepository, ServiceRepository>();            
            builder.Services.AddScoped<IServiceLocationRepository, ServiceLocationRepository>();
            builder.Services.AddScoped<IStaffAssistantRepository, StaffAssistantRepository>();
            builder.Services.AddScoped<IStaffRepository, StaffRepository>();
            builder.Services.AddScoped<ITestimonialRepository, TestimonialRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            // Service
            builder.Services.AddScoped<IBookingService, BookingService>();
            builder.Services.AddScoped<IClientService, ClientService>();
            builder.Services.AddScoped<ILocationService, LocationService>();
            builder.Services.AddScoped<IPartnerService, PartnerService>();
            builder.Services.AddScoped<IPaymentService, PaymentService>();
            builder.Services.AddScoped<IPromotionService, PromotionService>();
            builder.Services.AddScoped<IServiceService, ServiceService>();
            builder.Services.AddScoped<IServiceLocationService, ServiceLocationService>();
            builder.Services.AddScoped<IStaffAssistantService, StaffAssistantService>();
            builder.Services.AddScoped<IStaffService, StaffService>();
            builder.Services.AddScoped<ITestimonialService, TestimonialService>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IValidator<User>, UserValidator>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            // Enable CORS
            app.UseCors("AllowSpecificOrigins");

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
