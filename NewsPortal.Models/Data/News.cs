using System;

namespace NewsPortal.Models.Data
{
    public class News
    {
        public Guid NewsId { get; set; }
        public DateTime CreateDate { get; set; }
        public byte[] Photo { get; set; }
        public string Headline { get; set; }
        public string Review { get; set; }
        public string Text { get; set; }
    }
}
