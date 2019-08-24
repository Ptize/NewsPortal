﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPortal.Models.VeiwModels
{
    public class ChangeForgotPasswordVM
    {
        /// <summary>
        /// Идентификатор сущности
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Логин пользоваателя(он же почта)
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Новый пароль пользователя
        /// </summary>
        public string NewPassword { get; set; }
    }

    public class ChangePasswordVM
    {
        /// <summary>
        /// Идентификатор сущности
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Логин пользоваателя(он же почта)
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Новый пароль пользователя
        /// </summary>
        public string NewPassword { get; set; }
        /// <summary>
        /// Старый пароль пользователя
        /// </summary>
        public string OldPassword { get; set; }
    }
}
