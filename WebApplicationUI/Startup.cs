using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using WebApplicationUI.Models.DataContext;

namespace WebApplicationUI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        readonly IConfiguration conf;

        public Startup(IConfiguration configuration)
        {
            this.conf = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ToDoListDbConext>(cfg=> {
                cfg.UseSqlServer(conf.GetConnectionString("cString"));
            });

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            //wwwroot uchun
            app.UseStaticFiles();

            app.UseStaticFiles(new StaticFileOptions {
                FileProvider = new PhysicalFileProvider(
                     Path.Combine(env.ContentRootPath, "node_modules")),
                RequestPath = "/npm"
            });

            app.UseRouting();

            app.UseEndpoints(cfg =>
            {
                cfg.MapControllerRoute(
                    name: "default",
                    pattern: "{Controller=ToDoes}/{Action=Index}/{Id?}"
                    );
            });
        }
    }
}
