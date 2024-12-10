
using ExcerciseApi.Data;
using ExcerciseApi.Repository;
using Microsoft.EntityFrameworkCore;

namespace ExcerciseApi
{
    public class Program
    {
        // application entry point
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            // swagger ui
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // custom data repository
            builder.Services.AddTransient<IExcerciseDataRepository, ExcerciseDataRepository>();

            var app = builder.Build();

            // http request pipeline.
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
