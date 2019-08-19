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

            services.AddMvc();

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
                //c.RoutePrefix = string.Empty;
            });

            //app.UseMvc();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}");
                routes.MapSpaFallbackRoute("spa-fallback", new { controller = "Blog", action = "Index" });
            });
        }
    }
}
