using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace aspnet_vuejs_basetemplate
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


#if DEBUG
            // cors policy for work with double server
            app.UseCors(builder =>
               builder.WithOrigins("http://localhost:8080").AllowAnyHeader().AllowAnyMethod());
#endif
            // manage your 404 redirects from server
            app.Use(async (context, next) =>
                                {
                                    await next.Invoke();
                                    if (context.Response.StatusCode == 404)
                                        context.Response.Redirect("/");
                                });

            // if you need it => app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
