using NewsPortal.Models.VeiwModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Data.Registration
{
    public class ExternalAuthorizationProvider
    {
        public Task<ApplicationUserVM> Authorize(string login, string password)
        {
            throw new NotImplementedException();
        }
    }
}
