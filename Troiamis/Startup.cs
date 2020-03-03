using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Troiamis.ModelsCombined;

namespace Troiamis
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TroiamisDBContext>(opt => opt.UseSqlServer(Configuration["ConnectionStrings:cdb_conn"]));
            services.AddControllersWithViews();
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseSession();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "Home",
                    template: "{controller=Home}/{action=Index}");

                routes.MapRoute(
                    name: "Login",
                    template: "Login",
                    defaults: new { Controller = "Home", action = "Login" });

                //Template for additional routing
                //routes.MapRoute(
                //    name: "", name for it
                //    template: "Profile/{profileName?}", what you want in the search bar
                //    defaults: new { Controller = "Home", action = "Profile" }); controller, action

                //Template for additional routing
                //routes.MapRoute(
                //    name: "", name for it
                //    template: "Profile",
                //    defaults: new { Controller = "Home", action = "Profile" });

            });
        }
    }
}
