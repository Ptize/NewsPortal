using Microsoft.AspNetCore.Identity;
using NewsPortal.Models.Enums;

namespace NewsPortal.Models.Data
{
    public class ApplicationUser : IdentityUser
    {
        public Role SystemRole { get; set; }
        public string ApiKey { get; set; }
    }
}
