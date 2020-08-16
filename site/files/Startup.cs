using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VWAT.Services;
using VWAT.Repositories;
using VWAT.Config;

namespace VWAT
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddAuthentication("CookieAuthentication")
        .AddCookie("CookieAuthentication", config =>
        {
          config.LoginPath = "/Home/Index";
          config.Cookie.HttpOnly = false;
          config.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        });

      // services.AddAuthentication(options =>
      // {
      //   options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
      //   options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      // })
      // .AddJwtBearer(options =>
      // {
      //   options.RequireHttpsMetadata = false;
      //   options.SaveToken = true;
      //   options.TokenValidationParameters = new TokenValidationParameters
      //   {
      //     ValidateIssuerSigningKey = true,
      //     IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(configService.JwtKey)),
      //     ValidateIssuer = false,
      //     ValidateAudience = false
      //   };
      // });


      services.AddControllersWithViews()
          .AddRazorRuntimeCompilation();

      services.AddScoped<CommentService>();
      services.AddScoped<UserService>();

      services.AddScoped<CommentRepository>();
      services.AddScoped<UserRepository>();

      services.AddSingleton<AppConfig>(new AppConfig());
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
      }

      app.UseStaticFiles();
      app.UseRouting();

      app.UseAuthentication();
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
