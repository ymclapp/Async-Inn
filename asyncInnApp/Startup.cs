using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asyncInnApp.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace asyncInnApp
{
    public class Startup
    {
    //property to hold our configuration
    public IConfiguration Configuration { get; }

    //constructor to receive our configuration (a bit of magic here)
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    //- Register our DbContext with the app within ConfigureServices() services.AddDbContext()is called as a generic with our DbContext as the type - This will allow us to set options, such as connecting to our SQL Server


    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
        {
      services.AddDbContext<HotelsDBContext>(options => {
        // Our DATABASE_URL from js days
        string connectionString = Configuration.GetConnectionString("DefaultConnection");
        options.UseSqlServer(connectionString);
      });
    }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
              endpoints.MapGet("/HI", async context =>
              {
                await context.Response.WriteAsync("Hi!!!!!!!");
              });
              endpoints.MapGet("/500", async context =>
              {
                throw new InvalidOperationException("Boom!!!");
              });
            });
        }
    }
}
