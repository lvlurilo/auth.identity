using IdentityAuthentication.Crosscutting.Persistence;
using IdentityAuthentication.Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace IdentityAuthentication.Crosscutting
{
    public static class ServiceCollectionConfig
    {
        public static IServiceCollection AddContext(this IServiceCollection services, IConfiguration configuration)
        {
            // para criar a migration: add-migration InitialIdentityModel -OutputDir ".\Persistence\Migrations\", Update-Database

            var connString = configuration.GetConnectionString("DefaultConnectionString");

            services.AddDbContext<Context>(options => options.UseSqlServer(connString));

            return services;
        }

        public static IServiceCollection AddPasswordConfig(this IServiceCollection services)
        {
            services.AddIdentity<User, Role>(opt =>
            {
                opt.Password.RequireDigit = true;
                opt.Password.RequiredLength = 6;
            })
                .AddEntityFrameworkStores<Context>()
                .AddRoleValidator<RoleValidator<Role>>()
                .AddRoleManager<RoleManager<Role>>()
                .AddSignInManager<SignInManager<User>>()
                .AddDefaultTokenProviders();

            return services;
        }

        public static IServiceCollection AddAuthenticationConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration.GetSection("AppSettings:Secret").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            return services;
        }
    }
}
