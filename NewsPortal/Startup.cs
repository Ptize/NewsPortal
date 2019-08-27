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
using System.Reflection;
using System.IO;
using Microsoft.Extensions.Logging;
using static NewsPortal.Domain.Logging.LoggerExtensions.Main.StartupLogger;
using NewsPortal.Domain;

namespace NewsPortal
{
    public class Startup
    {
        private readonly ILogger _logger;

        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment, ILogger<Startup> logger)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(hostingEnvironment.ContentRootPath)
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddJsonFile($"appsettings.{hostingEnvironment.EnvironmentName}.json", reloadOnChange: true, optional: true)
               .AddEnvironmentVariables();

            Configuration = builder.Build();

            _logger = logger;
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
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                //c.IncludeXmlComments(string.Format(@"{0}\{1}", AppDomain.CurrentDomain.BaseDirectory, swaggerConf.Swagger.AppComments));

                //c.AddSecurityDefinition("ApiKey", new ApiKeyScheme
                //{
                //    Name = "ApiKey",
                //    In = "header",
                //    Type = "apiKey"
                //});

                // Схема ApiKey применяется к методам покрытым атрибутом "AuthorizeFilterAttribute"
                //c.OperationFilter<SecurityRequirementsOperationFilter>();
            });
            _logger.AddedSwagger();

            services.AddScoped<INewsRepository, NewsRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            _logger.AddedRepositories();

            services.AddScoped<INewsStorage, NewsStorage>();
            services.AddScoped<IUserStorage, UserStorage>();
            services.AddScoped<IRoleStorage, RoleStorage>();
            _logger.AddedStorages();

            services.AddScoped<NewsBuilder>();
            services.AddScoped<UserBuilder>();
            services.AddScoped<RoleBuilder>();
            _logger.AddedBuilders();

            services.AddScoped<EmailService>();

            services.AddAutoMapper(typeof(MappingProfile));
            _logger.AddedAutomapper();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                _logger.InDevelopment();
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                SwaggerSettings swaggerConf = new SwaggerSettings(Configuration);
                c.SwaggerEndpoint(swaggerConf.Swagger.EndPoint, swaggerConf.Swagger.Spec);
                //c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseAuthentication();

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
