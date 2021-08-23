using EPM.Implementation.CustomerImplementation;
using EPM.Implementation.EmployeeImplementation;
using EPM.Implementation.UserManagementImplementation;
using EPM.Repository.CustomerManagementRepo;
using EPM.Repository.EmployeeManagementRepo;
using EPM.Repository.UserManagementAuthenticate;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPM_UI
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
            services.AddTransient<ICustomer, CustomerImplementation>();
            services.AddTransient<IEmployee, EmployeeImplementation>();
            services.AddTransient<IAuthenticate , AuthenticateImplementation>(); //service.AddTransient<interfaceName , className>();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=LoginAuthenticate}/{action=LoginForm}/{id?}");
            });
        }
    }
}
