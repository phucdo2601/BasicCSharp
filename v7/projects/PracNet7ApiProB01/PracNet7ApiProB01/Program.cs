using Microsoft.EntityFrameworkCore;
using PracNet7ApiProB01.Model.Entities;
using PracNet7ApiProB01.Model.Infrastructures;
using Serilog;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PracNet7ApiDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configuration of SeriLog for writing log
//Log.Logger = new LoggerConfiguration().MinimumLevel.Information()
//    .WriteTo.Console()
//    .WriteTo.File("logs/debug-log.txt", rollingInterval: RollingInterval.Day)
//    .CreateLogger();

// Configuration of SeriLog for writing log on json file setup
Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).CreateLogger();

// Conmfigure Unit of Work for using repository
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

// Fix over loop for join table
builder.Services.AddMvc()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Add Serilog Config
builder.Host.UseSerilog();

// Add CORS 
builder.Services.AddCors();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Use CORS
app.UseCors(C => C.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

// Use Serilog Request
app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
