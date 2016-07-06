using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using MyWebApp.Models;

namespace MyWebApp
{
  public class Startup
  {

    public Startup(IHostingEnvironment env)
    {
      // Set up configuration sources.
      var builder = new ConfigurationBuilder()
        .SetBasePath(env.ContentRootPath)
          .AddJsonFile("appsettings.json", true, true)
          .AddEnvironmentVariables();
      Configuration = builder.Build();
    }

    public IConfigurationRoot Configuration { get; set; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {

      services.AddDbContext<Models.SpeakerDbContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

      services.AddSingleton(typeof(IConfigurationRoot), Configuration);

      // Add framework services.
      services.AddMvc();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
      loggerFactory.AddConsole(Configuration.GetSection("Logging"));
      loggerFactory.AddDebug();

      if (env.IsDevelopment())
      {
        app.UseBrowserLink();
        app.UseDeveloperExceptionPage();

      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
      }

      /// Seed the database
      using (var ctx = app.ApplicationServices.GetRequiredService<Models.SpeakerDbContext>())
      {
        ctx.EnsureSeedData();
      }


      app.UseStaticFiles();

      app.UseMvc(routes =>
      {
        routes.MapRoute(
                  name: "default",
                  template: "{controller=Home}/{action=Index}/{id?}");
      });
    }

  }
}
