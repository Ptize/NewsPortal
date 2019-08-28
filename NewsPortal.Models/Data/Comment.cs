using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NewsPortal.Models.Data
{
    public class Comment
    {
        public DateTime CreateDate { get; set; }
        public string Text { get; set; }
        [Key]
        public Guid NewsId { get; set; }
        [Key]
        public Guid UserId { get; set; }
    }
}
