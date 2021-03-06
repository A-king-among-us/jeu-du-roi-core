using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApp.Hubs;

namespace WebApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        /*Attention quand on est derri�re un reverse proxy nginx penser a mettre ces set header
         * proxy_set_header Connection "Upgrade";
         * proxy_set_header Upgrade $http_upgrade;
         */
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: "cors",
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:3000",//Le client ReactJS
                                                          "https://akau.weebo.fr",
                                                          "https://localhost:44395",
                                                          "https://akaucore.weebo.fr")
                                            .WithMethods("GET", "POST")
                                            .AllowCredentials()
                                            .AllowAnyHeader();
                                  });
            });
            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseRouting();
            app.UseCors("cors");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
                endpoints.MapHub<PartieHub>("/api");
            });
        }
    }
}
