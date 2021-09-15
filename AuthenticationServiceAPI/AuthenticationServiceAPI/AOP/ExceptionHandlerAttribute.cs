using AuthenticationServiceAPI.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AuthenticationServiceAPI.AOP
{
    public class ExceptionHandlerAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType() == typeof(UserAlreadyExistException))
            {
                context.Result = new NotFoundObjectResult(context.Exception.Message);
            }
            else if (context.Exception.GetType() == typeof(InvalidCredentialsException))
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
