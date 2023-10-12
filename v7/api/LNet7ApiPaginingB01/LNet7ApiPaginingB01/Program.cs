
using LNet7ApiPaginingB01.Entities;
using LNet7ApiPaginingB01.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace LNet7ApiPaginingB01
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

            // Configure dbContext for mapping table in db
            builder.Services.AddDbContext<AdventureWorks2022Context>(
            options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DeafautConnection"));
            }
            );

            //Fix over loop for join table
            builder.Services.AddMvc()
                .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            //Configure Unit of work for using repository
            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

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