using NewsPortal.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewsPortal.Models.VeiwModels
{
    /// <summary>
    /// Класс описывающий сущность комментария
    /// </summary>
    public class CommentVM
    {
        /// <summary>
        /// Дата добавления
        /// </summary>
        public DateTime? CreateDate { get; set; }

        /// <summary>
        /// Текст комментария
        /// </summary>
        [Required]
        public string Text { get; set; }

        /// <summary>
        /// Идентификатор новости к которой оставлен комментарий
        /// </summary>
        [Required]
        public Guid? NewsId { get; set; }

        /// <summary>
        /// Идентификатор сущности пользователя, коорый оставил комментарий
        /// </summary>
        [Required]
        public Guid? UserId { get; set; }
    }

    public class CommentsListVM
    {
        /// <summary>
        /// Количество страниц
        /// </summary>
        public int CountPage { get; set; }
        /// <summary>
        /// Список комментариев 
        /// </summary>
        public List<Comment> CommentsList { get; set; }
    }
}
