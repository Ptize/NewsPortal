using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortal.Filters
{
    public class ActionFilterValidationAttribute : ActionFilterAttribute
    {
        public IActionResult GetResult(IEnumerable<ModelError> errors)
        {
            return new BadRequestObjectResult(errors);
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext filterContext, ActionExecutionDelegate next)
        {
            if (!filterContext.ModelState.IsValid)
            {
                filterContext.Result = GetResult(filterContext.ModelState.Values.SelectMany(modelstate => modelstate.Errors));
            }
            else
            {
                await next();
            }
        }
    }
}
