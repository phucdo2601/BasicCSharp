using BlogWebApi.Application.UnitOfWork;
using BlogWebApi.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Configure Newtonsoft.Json for resolving  serialization cycle was detected when serializing data to JSON
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Configuration connecting project to mssql database
builder.Services.AddDbContext<ApplicationDbContext>(option =>{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
});

// Conifguration add unit of work for using repository
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

// Configure Serilog for logging
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .WriteTo.Console()
    .WriteTo.File("logs/MyAppLog.txt")
    .CreateLogger();

// Set Serilog as the logging provider
// This will also replace default logging provider with Serilog
builder.Host.UseSerilog();



// Set Auto Mapper for this project
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Configuration for using Swagger API by scalar
    app.MapScalarApiReference();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
