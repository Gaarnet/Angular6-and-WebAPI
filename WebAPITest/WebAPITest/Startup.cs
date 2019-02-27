using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebAPITest.Context;
using WebAPITest.Services;

namespace WebAPITest
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<StudentContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ConnectionStr")));

            services.AddTransient<IStudentServices, StudentServices>();
            services.AddTransient<ICourseServices, CourseServices>();
            services.AddTransient<INavBarService, NavBarService>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute("default", "{controller=student}/{action=default}/{id?}");
            //});

            app.UseCors(b => b.WithOrigins("*","http://localhost:4200", "http://localhost:4200/*", "https://localhost:44361/*", "https://localhost:44361/api/student/students").AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            StudentContext.SeedData(app.ApplicationServices);
        }
    }
}
