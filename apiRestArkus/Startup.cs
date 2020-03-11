using apiRestArkus.Config;
using apiRestArkus.Constants;
using Common.Config;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace apiRestArkus
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
            var config = Configuration.GetConnectionString("DefaultConnection");
            services.AddCors(options => { options.AddPolicy("Cors", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials()); });
            services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors("Cors");
            app.UseHttpsRedirection();


            app.UseWhen(x => (x.Request.Path.StartsWithSegments("/"+ControllerContants.Employer, StringComparison.OrdinalIgnoreCase)),
            builder =>
            {
                builder.UseMiddleware<Middleware>(Configuration);
            });
            app.UseWhen(x => (x.Request.Path.StartsWithSegments("/"+ControllerContants.Payroll, StringComparison.OrdinalIgnoreCase)),
            builder =>
            {
                builder.UseMiddleware<Middleware>(Configuration);
            });


            app.UseMvc();
        }
    }
}
