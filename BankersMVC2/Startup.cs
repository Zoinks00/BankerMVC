using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Data;
using Dapper;
using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Identity;
using BankersMVC2.Data;
using Microsoft.EntityFrameworkCore;


namespace BankersMVC2
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
            
            
            //add service for dbcontext to connect to database in MySql
            services.AddDbContext<UserContext>(opt => opt.UseMySQL
               (Configuration.GetConnectionString("bankers")));

            services.AddIdentity<IdentityUser, IdentityRole>()
                //call Dbcontext 
                .AddEntityFrameworkStores<UserContext>();
            services.AddScoped<IDbConnection>((s) =>
            {
                IDbConnection conn = new MySqlConnection(Configuration.GetConnectionString("bankers"));
                conn.Open();
                return conn;
            });
                              
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IBalanceRepository, BalanceRepository>();
            services.AddTransient<ITransRepository, TransRepository>();
            
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //add authentication middleware
            app.UseAuthentication();

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
