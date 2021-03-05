using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCode.Booking
{
    public class AirportCode
    {
        private string _airportCode;

        public AirportCode(string airportCode)
        {
            EnsureValidAirportCode(airportCode);
        }


        public override string ToString()
        {
            return _airportCode;
        }

        private void EnsureValidAirportCode(string airportCode)
        {
            var isWrongLength = airportCode.Length != 3;

            var isWrongCase = airportCode != airportCode.ToUpperInvariant();

            if (isWrongLength || isWrongCase)
            {
                throw new Exception(airportCode + " is an invalid airport");
            }
            else
            {
                _airportCode = airportCode;
            }
        }
    }
}
