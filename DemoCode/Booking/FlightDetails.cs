using System;
using System.Collections.Generic;

namespace DemoCode.Booking
{
    public class FlightDetails
    {

        public AirportCode DepartureAirportCode { get; }

        public AirportCode ArrivalAirportCode { get; }

        public TimeSpan FlightDuration { get; set; }
        public string AirlineName { get; set; }
        public List<string> MealOptions { get; set; } = new List<string>();

        public FlightDetails(AirportCode departureAirportCode, AirportCode arrivalAirportCode)
        {

            DepartureAirportCode = departureAirportCode;
            ArrivalAirportCode = arrivalAirportCode;
        }
    }
}