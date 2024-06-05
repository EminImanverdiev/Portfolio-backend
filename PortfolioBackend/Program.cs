using FluentValidation.AspNetCore;
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
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers().AddFluentValidation(opt =>
            {
                opt.ImplicitlyValidateChildProperties = true;
                opt.ImplicitlyValidateRootCollectionElements = true;
                opt.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // CORS siyas?tini ?lav? edin
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder =>
                    {
                        builder.WithOrigins("http://127.0.0.1:5500")
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });

            builder.Services.AddApiConfiguration(builder.Configuration);
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles(); 
            // CORS siyas?tini istifad? edin
            app.UseCors("AllowSpecificOrigin");

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
