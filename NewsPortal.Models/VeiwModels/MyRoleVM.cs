using System.Collections.Generic;

namespace NewsPortal.Models.VeiwModels
{
    public class MyRoleVM
    {
        public string UserId { get; set; }
        public string UserEmail { get; set; }
        public IList<string> UserRoles { get; set; }

        public MyRoleVM()
        {
            UserRoles = new List<string>();
        }
    }
}
