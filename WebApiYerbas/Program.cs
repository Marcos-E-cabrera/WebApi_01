using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using WebApiYerbas.Models;
using WebApiYerbas.Services;

namespace WebApiYerbas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddScoped<IYerbaServices, YerbaServices>(); // injection services
           
            builder.Services.AddDbContext<YerbasApiRestContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("YerbasApiRestContext")); // injection base de datos
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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