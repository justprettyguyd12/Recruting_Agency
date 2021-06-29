using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Recruting_Agency_POP.Data.Interfaces;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Recruting_Agency_POP.Data;
using Recruting_Agency_POP.Data.Repository;
using Recruting_Agency_POP.Data.Models;
using System.Configuration;

namespace Recruting_Agency_POP
{
    public class Startup
    {
        private IConfigurationRoot _confstring;

        public IConfiguration Configuration { get; }

        public Startup (IWebHostEnvironment hostEnv, IConfiguration configuration)
        {
            _confstring = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            IServiceCollection serviceCollections = services.AddDbContext<AppDBContent>(options => 
                options.UseSqlServer(_confstring.GetConnectionString("DefaultConnections")));
            services.AddTransient<IAllResumes, ResumeRepository>();
            services.AddTransient<IAllVacancies, VacancyRepository>();
            services.AddRazorPages();
            services.AddMvc(options => options.EnableEndpointRouting = false);

            //authentication
            services.AddAuthentication("Cookie")
                .AddCookie("Cookie", config =>
                {
                    config.LoginPath = "/Account/Login";
                });
            services.AddAuthorization();

            //for Identity
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
            }
            ).AddEntityFrameworkStores<IdentityAppContext>();

            services.AddDbContext<IdentityAppContext>(cgf =>
            {
                cgf.UseSqlServer(_confstring.GetConnectionString("DefaultConnections"));
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AppDBContent content;
            using (var scope = app.ApplicationServices.CreateScope())
            {
                content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
                DbObjects.Initial(content);
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseStatusCodePages();
                app.UseStaticFiles();
                IApplicationBuilder applicationBuilder = app.UseMvcWithDefaultRoute();
            }

            else if (env.IsProduction())
            {
                app.Run(async (context) =>
                {
                    await context.Response.WriteAsync("Production!");
                });
            }

            app.UseRouting();

            //users data
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                /*
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
                */
            });
        }
    }
}
