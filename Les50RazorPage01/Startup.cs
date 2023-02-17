using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Les50RazorPage01
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //dang ky razor page
            // Thêm các dịch vụ liên quan đến Razor Page, đổi thư mục lưu trữ thành /Views
            /*services.AddRazorPages().WithRazorPagesRoot("/Views");*/

            services.AddRazorPages().AddRazorPagesOptions(options =>
            {
                options.RootDirectory="/Views";
                //cau hinh lai ten duong dan truy cap
                options.Conventions.AddPageRoute("/FirstPage", "trang-dau-tien.html");
                options.Conventions.AddPageRoute("/SecondPage", "test2");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages(); // thiep lap ma nguon trang razor pages

                //thiet lap endpoint cho firstPage


                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }

    /**
     * Razor page (.cshtml) = html + c#
     * Engine Razor -> Bien dich cshtml -> Response
     *  -@page
     *  -@bien, @(bieu-thuc), @phuongthuc
     * @{
     *  //viet code c#
     * }
     *  
     *  Rewrite Url
     *  
     *  @page "url"
     */
}
