using FlightServiceAPI.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FlightServiceAPI.AOP
{
    public class ExceptionHandlerAttribute:ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType() == typeof(InvalidAirlineException))
            {
                context.Result = new NotFoundObjectResult(context.Exception.Message);
            }
            else if (context.Exception.GetType() == typeof(InvalidFlightException))
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
