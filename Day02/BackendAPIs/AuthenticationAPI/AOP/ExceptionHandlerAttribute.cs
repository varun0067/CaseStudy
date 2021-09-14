using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using AuthenticationAPI.Exceptions;

namespace AuthenticationAPI.AOP
{
    public class ExceptionHandlerAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType() == typeof(UserAlreadyExistException))
            {
                context.Result = new NotFoundObjectResult(context.Exception.Message);
            }
            else if (context.Exception.GetType() == typeof(UserNameandPassWordNullException))
            {
                context.Result = new NotFoundObjectResult(context.Exception.Message);
            }
            else if (context.Exception.GetType() == typeof(UserNotFoundException))
            {
                context.Result = new NotFoundObjectResult(context.Exception.Message);
            }
            else
            {
                context.Result = new StatusCodeResult(500);
            }
        }
    }
}
