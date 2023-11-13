using AquiPaga_API_RESTful.Mapping;
using AquiPaga_API_RESTful.Repositories;
using AquiPaga_API_RESTful.Repositories.Interfaces;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace AquiPaga_API_RESTful
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<ITaskRepository, TaskRepository>();
            builder.Services.AddAutoMapper(typeof(StartupBase));
            builder.Services.AddAutoMapper(typeof(TaskMapping));

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