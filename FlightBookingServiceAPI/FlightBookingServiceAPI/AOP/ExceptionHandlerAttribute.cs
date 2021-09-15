using FlightBookingServiceAPI.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FlightBookingServiceAPI.AOP
{
    public class ExceptionHandlerAttribute:ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType() == typeof(TicketDetailsNotFoundException))
            {
                context.Result = new NotFoundObjectResult(context.Exception.Message);
            }
            else if (context.Exception.GetType() == typeof(CancelTicketTimeLimitException))
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
