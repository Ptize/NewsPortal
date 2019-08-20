using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NewsPortal.Data.Registration;
using NewsPortal.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortal.Filters
{
    public class ExternalRoleFilterAttribute : ActionFilterAttribute
    {
        private readonly UserContext _userContext;
        private readonly Role _roleFilter;

        public ExternalRoleFilterAttribute(UserContext userContext, Role roleFilter)
        {
            _userContext = userContext;
            _roleFilter = roleFilter;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (_userContext.Role != _roleFilter)
            {
                context.Result = new StatusCodeResult(403);
            }
        }

    }
}
