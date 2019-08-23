using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPortal.Models.VeiwModels
{
    public class UsersListVM
    {
        /// <summary>
        /// Количество страниц
        /// </summary>
        public int CountPage { get; set; }
        /// <summary>
        /// Список пользователей 
        /// </summary>
        public List<BriefUserVM> UsersList { get; set; }
    }

    public class BriefUserVM
    {
        /// <summary>
        /// Идентификатор сущности
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Логин пользоваателя(он же почта)
        /// </summary>
        public string Email { get; set; }
    }
}
