using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCode.Booking
{
    public class FlightBooking
    {
        public string BookingReference { get; set; }
        public string CustomerName { get; set; }
        public List<FlightDetails> Legs { get; set; } = new List<FlightDetails>();
    }
}
