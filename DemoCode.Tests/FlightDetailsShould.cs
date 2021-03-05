using System;
using System.Collections.Generic;
using System.Text;
using AutoFixture;
using FluentAssertions;
using NUnit.Framework;
using Moq;
using DemoCode.Booking;

namespace DemoCode.Tests
{
    public class FlightDetailsShould
    {
        [Test]
        [Ignore("Refactored code to use AirportCode Class")]
        public void Error()
        {
            var fixture = new Fixture();

            //// ************** INJECT: Flight details needs to generate a specific layout of string so no error is thrown.
            //// ************** Therefore, we need to use the fixture.Inject method.
            //// ************** This will create the same string for all strings Autofixture needs to create.
            //fixture.Inject<string>("LHR");

            ////// ************** Instead, we need to inject a whole new object
            //fixture.Inject(new FlightDetails
            //{
            //    DepartureAirportCode = "PER",
            //    FlightDuration = It.IsAny<TimeSpan>(),
            //    ArrivalAirportCode = "LHR",
            //    AirlineName = It.IsAny<string>()
            //});

            //// ************** REGISTER: Write a function to specify how to create any strings.
            //fixture.Register<string>(() => DateTime.Now.Ticks.ToString());
            // var flight = fixture.Create<FlightDetails>();


            //// ************** BUILD + CREATE: We can specify to not include some properties and specify the props when creted using .WITH, .WITHOUT and .DO (does some action on the prop)
            //fixture.Build<FlightDetails>()
            //    .Without(x => x.MealOptions)
            //    .With(x=> x.ArrivalAirportCode, "LHR")
            //    .With(x=> x.DepartureAirportCode, "LAX")
            //    .Do(x=> x.MealOptions.Add("Chicken"))
            //    .Do(x=> x.MealOptions.Add("Vegan"))
            //    .Create();

            //// ************** CUSTOMISE: Customise how it is created, do not need to call Create on it. Need to specify using a function, the WITH, WITHOUT, DO methods
            fixture.Customize<FlightDetails>(x =>
                   x.Without(x => x.MealOptions)
                       //.With(x => x.ArrivalAirportCode, "LHR")
                       //.With(x => x.DepartureAirportCode, "LAX")
                       .Do(x => x.MealOptions.Add("Chicken"))
                       .Do(x => x.MealOptions.Add("Vegan")));

            var flight = fixture.Create<FlightDetails>();
        }

        /* *************** Using Autofixture to refactor code.
         When needing to inject some data for a specific prop, this may show that we need a strongly typed object to inject instead.*/
        [Test]
        public void CalculateTotalFlightTime()
        {
            var fixture = new Fixture();
            // ************** We only wan to inject an Airport Code String, not every string. So let's change our code to reflect this.
            // fixture.Inject("LHR")
            fixture.Inject(new AirportCode("LHR"));

            var sut = fixture.Create<FlightBooking>();
        }
    }
}
