using System;
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
        /// неверный идентификатор
        /// </summary>
        InvalidId = 1,
        /// <summary>
        /// недопустимый пароль
        /// </summary>
        InvalidPassword = 2,
        /// <summary>
        /// недопустимый пароль
        /// </summary>
        UnknounError = 3
    }
}
