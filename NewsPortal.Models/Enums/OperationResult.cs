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
        /// неизвестная ошибка
        /// </summary>
        UnknounError = 3,
        /// <summary>
        /// не подтверждёна почта
        /// </summary>
        MailNotConfirmed = 4,
        /// <summary>
        /// не создался URL
        /// </summary>
        InvalidUrl = 5
    }
}
