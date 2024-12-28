using BlogWebApi.Application.UnitOfWork;
using BlogWebApi.Domain.Dtos;
using BlogWebApi.Model.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using Serilog;
using System.Text;

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

// Configuration for reading in applications.json
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

// Set Auto Mapper for this project
builder.Services.AddAutoMapper(typeof(Program));

// Set up JWT Bearer Token For Authentication
var secretKey = builder.Configuration["AppSettings:SecretKey"];
var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        // auto generate token
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,

        // sign data on token string
        ValidateIssuerSigningKey = true,
        ValidIssuer = "YourIssuer",
        ValidAudience = "YourAudience",
        IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),

        ClockSkew = TimeSpan.Zero,
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Configuration for using Swagger API by scalar
    app.MapScalarApiReference();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
