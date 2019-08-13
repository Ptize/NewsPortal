using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace NewsPortal.Swagger
{
    /// <summary>
    /// Класс для описания настроек Swagger
    /// </summary>
    public class SwaggerSettings
    {
        /// <summary>
        /// Путь к ресурсу Swagger
        /// </summary>
        public string RoutePrefix { get; set; }
        /// <summary>
        /// Список из ресурсов Swagger
        /// </summary>
        public SwaggerElementDescription Swagger { get; set; }

        public SwaggerSettings()
        {
            RoutePrefix = "";
            Swagger = new SwaggerElementDescription();
        }

        /// <summary>
        /// Считывание настроек из appsettings.json
        /// </summary>
        /// <param name="Configuration">Переменная конфигурации для взаимодействия с appconfig.json</param>
        public SwaggerSettings(IConfiguration Configuration)
        {
            SwaggerSettings swaggerConf = Configuration.GetSection("SwaggerSettings").Get<SwaggerSettings>();
            this.RoutePrefix = swaggerConf.RoutePrefix;
            this.Swagger = swaggerConf.Swagger;
        }
    }
}
