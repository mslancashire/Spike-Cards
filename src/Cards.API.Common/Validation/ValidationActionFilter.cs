using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Cards.API.Common.Validation;

public class ValidationActionFilter : IActionFilter
{
    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.ModelState.IsValid)
        {
            return;
        }

        context.Result = new BadRequestObjectResult(context.ModelState.ToProblemDetails(context.HttpContext));
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        // no action needed.
    }
}
