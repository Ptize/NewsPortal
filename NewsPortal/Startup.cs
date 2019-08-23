using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
using NewsPortal.Data.Repository.interfaces;
using NewsPortal.Data.Repository;

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
                //c.AddSecurityDefinition("ApiKey", new ApiKeyScheme
                //{
                //    Name = "ApiKey",
                //    In = "header",
                //    Type = "apiKey"
                //});

                // Схема ApiKey применяется к методам покрытым атрибутом "AuthorizeFilterAttribute"
                //c.OperationFilter<SecurityRequirementsOperationFilter>();
            });

            services.AddScoped<INewsRepository, NewsRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();

            services.AddScoped<INewsStorage, NewsStorage>();
            services.AddScoped<IUserStorage, UserStorage>();
            services.AddScoped<IRoleStorage, RoleStorage>();

            services.AddScoped<NewsBuilder>();
            services.AddScoped<UserBuilder>();
            services.AddScoped<RoleBuilder>();

            services.AddAutoMapper(typeof(MappingProfile));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                SwaggerSettings swaggerConf = new SwaggerSettings(Configuration);
                c.SwaggerEndpoint(swaggerConf.Swagger.EndPoint, swaggerConf.Swagger.Spec);
                c.RoutePrefix = string.Empty;
            });
            
            //app.UseAuthentication();

            app.UseMvc();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}");
            });
        }
    }
}
