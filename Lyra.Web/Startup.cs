using Lyra.DataAccess;
using Lyra.DataAccess.Model;
using Lyra.Web.Configuration.IoC;
using Lyra.Web.Extensions;
using Lyra.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StructureMap;
using System;

namespace Lyra.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, Role>(setup =>
            {
                setup.Password.RequireUppercase = false;
                setup.Password.RequireNonAlphanumeric = false;
                setup.Password.RequiredLength = 6;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc(options =>
            {
                options.Filters.Add<GameFilterAttribute>();
            });

            return ConfigurteIoC(services);
        }

        public IServiceProvider ConfigurteIoC(IServiceCollection services)
        {
            var container = new Container();

            container.Configure(c =>
            {
                c.Scan(scaner =>
                {
                    scaner.TheCallingAssembly();
                    scaner.WithDefaultConventions();
                });

                c.AddRegistry<DataAccessRegistry>();
                c.AddRegistry<ServicesRegistry>();
                c.AddRegistry<WebRegistry>();
                c.Populate(services);
            });

            return container.GetInstance<IServiceProvider>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
