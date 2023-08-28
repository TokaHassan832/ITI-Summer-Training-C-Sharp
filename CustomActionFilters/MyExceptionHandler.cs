using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace mvc1.CustomActionFilters
{
    public class MyExceptionHandler : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null)
            {
                context.ExceptionHandled = true;
                context.Result = new ContentResult()
                {
                    Content = "Exception Handled",
                };
            }
            base.OnActionExecuted(context);
        }
    }
}
