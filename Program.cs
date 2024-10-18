using AS_Ministry_Of_Finance_API.ExcelLoader;
using AS_Ministry_Of_Finance_API.Models; // Adjust this to match the namespace where AppDbContext is located
using Microsoft.EntityFrameworkCore;
using System;
using System.Text.Json.Serialization;

namespace AS_Ministry_Of_Finance_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.


            //Add cores
            builder.Services.AddCors();

            // Register AppDbContext with SQL Server connection string
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


            builder.Services.AddScoped<ExcelDataService>();


            builder.Services.AddControllers();

            // Enable Swagger for API documentation
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
            }

            app.UseHttpsRedirection();
            app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.UseAuthorization();

            app.MapControllers();
               
                app.UseSwagger();
                app.UseSwaggerUI();

            app.Run();
        }
    }
}
