using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NewsPortal.Data.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortal.Filters
{
    public class ExternalAuthorizeFilterAttribute : ActionFilterAttribute
    {
        private readonly UserContext _userContext;

        public ExternalAuthorizeFilterAttribute(UserContext userContext)
        {
            _userContext = userContext;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (_userContext.UserId == null)
            {
                context.Result = new StatusCodeResult(401);
            }
        }
    }
}
