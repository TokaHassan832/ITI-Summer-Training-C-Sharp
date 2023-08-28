using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace mvc1.CustomActionFilters
{
    public class MyAuthorizeFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.User.Identity.IsAuthenticated) 
            {
                context.Result = new BadRequestResult();
            }
            base.OnActionExecuting(context);
        }
    }
}
