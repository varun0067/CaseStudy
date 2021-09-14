using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookingServiceAPI.DTO
{
    public class CancelSingleTicketDTO
    {
        public string Email { get; set; }
        public string PNR { get; set; }
    }
}
