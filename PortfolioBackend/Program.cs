using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using PortfolioBackend.Repositories.EFcore;
using System.Reflection;

namespace PortfolioBackend
{
    public class Program
    {
        [Obsolete]
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
            builder.Services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration["ConnectionStrings:Default"]);
            });
            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}