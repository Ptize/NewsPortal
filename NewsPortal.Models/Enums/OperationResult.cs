﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPortal.Models.Enums
{
    /// <summary>
    /// Результат операции
    /// </summary>
    public enum OperationResult
    {
        /// <summary>
        /// операция завершилась успешно
        /// </summary>
        Success = 0,
        /// <summary>
        /// не верный идентификатор
        /// </summary>
        InvalidId = 1,
        /// <summary>
        /// не допустимый пароль
        /// </summary>
        InvalidPassword = 1
    }
}
