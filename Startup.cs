using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace razor08.efcore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddRazorPages();
            services.AddDbContext<MyBlogContext>(options =>
            {
                string connectString = Configuration.GetConnectionString("MyBlogContext");
                options.UseSqlServer(connectString);
            });

            services.AddDbContext<MyBlogContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("MyBlogContext")));

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            // Chuyển hướng https
            app.UseHttpsRedirection();
            // Kích hoạt truy cập file tĩnh (file trong wwwroot)
            app.UseStaticFiles();

            app.UseRouting();


            app.UseEndpoints(endpoints =>
            {
                // Thêm endpoint chuyển đến các trang Razor Page
                // trong thư mục Pages
                endpoints.MapRazorPages();
            });
        }
    }
}

/*
CRUD
dotnet aspnet-codegenerator razorpage -m razor08.efcore.Article -dc razor08.efcore.Model.MyBlogContext -outDir Pages/Blog -udl --referenceScriptLibraries

*/