using EmployeeMgt.Core.Mappings;
using EmployeeMgt.Data;
using EmployeeMgt.Data.Interface;
using EmployeeMgt.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMgt.Web
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
            services.AddDbContext<EmpMgtContext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("EmployeeData"));
            });


            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserLoginRepository, UserLoginRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();

            //For Redirecting Unauthorized User/Acces. 
            services.AddAuthentication("EmployeeSecureClaims")
                .AddCookie("EmployeeSecureClaims", config =>
                {
                    config.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                    config.Cookie.Name = "EmpCookie";
                    config.LoginPath = "/Home/Login";
                    config.SlidingExpiration = true;
                    config.AccessDeniedPath = "/Home/Login";
                    config.ClaimsIssuer = "Bitnets";
                });
            

            services.AddAutoMapper(typeof(Maps));

            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddMvc();
            services.AddRazorPages();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
