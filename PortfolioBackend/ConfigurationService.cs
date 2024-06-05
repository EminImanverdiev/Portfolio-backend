using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PortfolioBackend.DAL.Repositories.Abstracts;
using PortfolioBackend.DAL.Repositories.Concretes.EFCore;
using PortfolioBackend.Entities.Auth;
using PortfolioBackend.Repositories.EFcore;
using System.Reflection;
using System.Text;

namespace PortfolioBackend
{
    public static class ConfigurationService
    {
        public static IServiceCollection AddApiConfiguration(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(configuration["ConnectionStrings:Default"]);
            });
            TokenOption tokenOption = configuration.GetSection("TokenOptions").Get<TokenOption>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
            services.AddAuthentication(opt =>
            {
                opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = tokenOption.Issuer,
                    ValidAudience = tokenOption.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOption.SecurityKey))
                };
            });
            services.AddScoped<IAboutRepository, EFAboutRepository>();
            services.AddScoped<IContactRepository, EFContactRepository>();
            services.AddScoped<IServiceRepository, EFServiceRepository>();
            services.AddScoped<IContactFormRepository, EFContactFormRepository>();
            services.AddScoped<IResumeRepository, EfResumeRepository>();
            services.AddScoped<ITestimonialRepository, EFTestimonialRepository>();
            return services;
        }
    }

    class ResumeRepository
    {
    }
}
