using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPortal.Models.Enums
{
    /// <summary>
    /// Роль в системе
    /// устанавливается вручную
    /// </summary>
    public enum Role
    {
        /// <summary>
        /// Не известный пользователь
        /// значение по умолчанию
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// Разработчик
        /// </summary>
        Developer = 1,
        /// <summary>
        /// Администратор
        /// </summary>
        Admin = 2,
        /// <summary>
        /// Пользователь
        /// </summary>
        SimpleUser = 3
    }
}
