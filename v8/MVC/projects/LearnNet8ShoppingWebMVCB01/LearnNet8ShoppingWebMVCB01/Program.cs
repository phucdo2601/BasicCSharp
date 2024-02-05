using LearnNet8ShoppingWebMVCB01.Data;
using LearnNet8ShoppingWebMVCB01.Helpers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

/**
 * Add DbContext
 */
builder.Services.AddDbContext<Hshop2023Context>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection"));
});
/**
 * Add Session Config
 */
builder.Services.AddDistributedMemoryCache();

/**
 * Add autoMapper config
 */
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromDays(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

/**
 * Add config authentication
 */
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = "/KhachHang/DangNhap";
    options.AccessDeniedPath = "/AccessDenied";

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

/**
 * Using Session
 */
app.UseSession();

/**
 * Use Authentication
 */
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
