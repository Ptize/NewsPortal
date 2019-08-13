using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortal.Swagger
{
    /// <summary>
    /// Описание разделов swagger
    /// </summary>
    public class SwaggerElementDescription
    {
        /// <summary>
        /// Путь к json файлу
        /// </summary>
        public string EndPoint { get; set; }
        /// <summary>
        /// Название страницы в выпадающем списке
        /// </summary>
        public string Spec { get; set; }
        public string Version { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string AppComments { get; set; }
        public string ModelsComments { get; set; }
    }
}
