using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using NewsPortal.Data;
using NewsPortal.Swagger;
using NewsPortal.Data.interfaces;
using NewsPortal.Domain.Storage;
using NewsPortal.Domain.Storage.Interfaces;
using NewsPortal.Domain.Builder;
using NewsPortal.Domain.Mapping;
using Microsoft.AspNetCore.Routing;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using NewsPortal.Models.Data;
using NewsPortal.Domain;
using Microsoft.AspNetCore.Authentication;

namespace NewsPortal
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(hostingEnvironment.ContentRootPath)
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddJsonFile($"appsettings.{hostingEnvironment.EnvironmentName}.json", reloadOnChange: true, optional: true)
               .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(opt => opt.UseNpgsql(Configuration.GetConnectionString("NewsPortalDbConnectionString")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options => options.AccessDeniedPath = "/Home/AccessDenied");

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.WithOrigins("http://example.com");
                });
            });

            services.AddLogging();

            // Add MVC services to the services container
            services.AddMvc();
            // Add memory cache services
            services.AddMemoryCache();
            services.AddDistributedMemoryCache();

            // Add session related services.
            services.AddSession();

            // Add the system clock service
            services.AddSingleton<ISystemClock, SystemClock>();

            // Configure Auth
            services.AddAuthorization(options =>
            {
                options.AddPolicy(
                    "ManageStore",
                    authBuilder =>
                    {
                        authBuilder.RequireClaim("ManageStore", "Allowed");
                    });
            });


            services.AddAuthentication()
                .AddFacebook(options =>
                {
                    options.AppId = "550624398330273";
                    options.AppSecret = "10e56a291d6b618da61b1e0dae3a8954";
                })
                .AddGoogle(options =>
                {
                    options.ClientId = "995291875932-0rt7417v5baevqrno24kv332b7d6d30a.apps.googleusercontent.com";
                    options.ClientSecret = "J_AT57H5KH_ItmMdu0r6PfXm";
                })
                .AddTwitter(options =>
                {
                    options.ConsumerKey = "lDSPIu480ocnXYZ9DumGCDw37";
                    options.ConsumerSecret = "fpo0oWRNc3vsZKlZSq1PyOSoeXlJd7NnG4Rfc94xbFXsdcc3nH";
                })
            // The MicrosoftAccount service has restrictions that prevent the use of
            // http://localhost:5001/ for test applications.
            // As such, here is how to change this sample to uses http://ktesting.com:5001/ instead.

            // From an admin command console first enter:
            // notepad C:\Windows\System32\drivers\etc\hosts
            // and add this to the file, save, and exit (and reboot?):
            // 127.0.0.1 ktesting.com

            // Then you can choose to run the app as admin (see below) or add the following ACL as admin:
            // netsh http add urlacl url=http://ktesting:5001/ user=[domain\user]

            // The sample app can then be run via:
            // dnx . web
                .AddMicrosoftAccount(options =>
                {
                    // MicrosoftAccount requires project changes
                    options.ClientId = "000000004012C08A";
                    options.ClientSecret = "GaMQ2hCnqAC6EcDLnXsAeBVIJOLmeutL";
                });

            SwaggerSettings swaggerConf = new SwaggerSettings(Configuration);
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(swaggerConf.Swagger.Version, new Info
                {
                    Version = swaggerConf.Swagger.Version,
                    Title = swaggerConf.Swagger.Title,
                    Description = swaggerConf.Swagger.Description
                });
                c.IncludeXmlComments(string.Format(@"{0}\{1}", AppDomain.CurrentDomain.BaseDirectory, swaggerConf.Swagger.AppComments));
            });

            services.AddScoped<INewsRepository, NewsRepository>();

            services.AddScoped<INewsStorage, NewsStorage>();

            services.AddScoped<NewsBuilder>();
            
            services.AddAutoMapper(typeof(MappingProfile));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                SwaggerSettings swaggerConf = new SwaggerSettings(Configuration);
                c.SwaggerEndpoint(swaggerConf.Swagger.EndPoint, swaggerConf.Swagger.Spec);
                c.RoutePrefix = string.Empty;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            // Configure Session.
            app.UseSession();

            app.UseMvc();

            app.UseMvc(routes =>
            {
                routes.MapRoute("api/get", async context =>
                {
                    await context.Response.WriteAsync("для обработки использован маршрут api/get");
                });

                routes.MapRoute("default",
                    "{controller}/{action}/{id?}",
                    new { controller = "Home", action = "Index" }
                );
            });
        }
    }
}
