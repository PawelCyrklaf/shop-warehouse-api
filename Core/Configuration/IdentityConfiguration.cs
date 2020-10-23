using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ShopWarehouse.API.Data.Models;

namespace ShopWarehouse.API.Core.Configuration
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection IdentityConfiguration(this IServiceCollection services, IConfiguration config)
        {

            services.AddIdentity<IdentityUser, IdentityRole>(
                    option =>
                    {
                        option.User.RequireUniqueEmail = true;
                        option.Password.RequireDigit = true;
                        option.Password.RequiredLength = 6;
                        option.Password.RequireNonAlphanumeric = true;
                        option.Password.RequireUppercase = true;
                        option.Password.RequireLowercase = true;
                    }
                ).AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(option => {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => {
                options.SaveToken = true;
                options.RequireHttpsMetadata = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ClockSkew = TimeSpan.Zero,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = config["Jwt:Site"],
                    ValidIssuer = config["Jwt:Site"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:SigningKey"]))
                };
            });
            return services;
        }
    }
}
