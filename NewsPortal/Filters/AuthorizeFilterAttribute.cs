using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NewsPortal.Domain.Registration;

namespace NewsPortal.Filters
{
    public class AuthorizeFilterAttribute : ActionFilterAttribute
    {
        private readonly UserContext _userContext;

        public AuthorizeFilterAttribute(UserContext userContext)
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
