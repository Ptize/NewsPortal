using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NewsPortal.Models.VeiwModels
{
    /// <summary>
    /// Класс описывает Новость
    /// </summary>
    public class NewsVM
    {
        /// <summary>
        /// Идентификатор сущности
        /// </summary>
        public Guid? NewsId { get; set; }

        /// <summary>
        /// Дата добавления
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Изображение, прикреплённое к новости
        /// </summary>
        public byte Photo { get; set; }

        /// <summary>
        /// Заголовок новости
        /// </summary>
        [Required]
        public string Headline { get; set; }

        /// <summary>
        /// Краткое ревью новости
        /// </summary>
        [Required]
        public string Review { get; set; }

        /// <summary>
        /// Основной текст новости
        /// </summary>
        [Required]
        public string Text { get; set; }
    }
}
