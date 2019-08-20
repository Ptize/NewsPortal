using NewsPortal.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPortal.Data.Registration
{
    public class UserContext
    {
        public Guid? UserId { get; set; }
        public Role Role { get; set; }
    }
}
