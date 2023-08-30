using Microsoft.EntityFrameworkCore;
using MyShopLearnEntityFrameOnNet6.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//add dbContext
builder.Services.AddDbContext<LearnEntityFrameOnNetCore6Context>(option => option.UseSqlServer(
    builder.Configuration.GetConnectionString("DbConnect")));

/**
 * Project nay su dung entity Framework theo huong database first (Scaffold) de generate enitty tu database co san:
 * Trong truong hop chua co entities nao cua db ton tai trong du an, chay cau lenh nay:
 *      - Scaffold-DbContext "Data Source=LAPTOP-7CKON28R\SQLEXPRESS;Initial Catalog=LearnEntityFrameOnNetCore6;User ID=sa;Password=12345678" Microsoft.EntityFrameworkCore.SqlServer -OutputDir nameFolderGenEntites
 * Neu phia database co su thay doi thi chung ta them -f sau cau lenh o tren:
 *      - Scaffold-DbContext "Data Source=LAPTOP-7CKON28R\SQLEXPRESS;Initial Catalog=LearnEntityFrameOnNetCore6;User ID=sa;Password=12345678" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Entities -f
 */

//add CORS for api can be connect with any domains(Reactjs, Angular,...)
builder.Services.AddCors(p => p.AddPolicy("MyCors", build =>
{
    //xac dinh cac resouce dc ket noi voi api nay
    // build.WithOrigins("https://hieplth.info", "https://localhost:3000");
    //tat ca cac resource deu co the ket noi voi api nay
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//bat CORS vua dc dinh nghia
app.UseCors("MyCors");

app.UseAuthorization();

app.MapControllers();

app.Run();
