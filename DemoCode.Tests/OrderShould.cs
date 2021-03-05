using AutoFixture;
using FluentAssertions;
using NUnit.Framework;

namespace DemoCode.Tests
{
    public class OrderShould
    {

        [Test]
        public void CreateCustomerObjectAswell()
        {
            var fixture = new Fixture();

            //var id = fixture.Create<int>();
            //fixture.Inject(id);
            //var customerName = fixture.Create<string>();
            //fixture.Inject(customerName);
            
            // ***********  FREEZE(): If we would like yo specify the type and returns the SAME VARIABLES, instead of using Create(), then Inject() --> Freeze()
            var id = fixture.Freeze<int>();
            var customerName = fixture.Freeze<string>();

            //// *********** Using a pre-build customisation: Converting a autonomous datetime to DateTimeNow
            //// *********** currentDateTimeCustomisation inherits from ICustomization, so we need to call Customise and pass it as a param.
            fixture.Customize(new CurrentDateTimeCustomization());
            ////  *********** CurrentDateTimeGenerator inherits ISpecimenBuilder (to create a specien = a specific type from a Tye e.g. 72 is a specimen of int.
            ////  *********** Therefore, we can add it to the Customisations property.
            fixture.Customizations.Add(new CurrentDateTimeGenerator());

            Order sut = fixture.Create<Order>();

            sut.Customer.Should().NotBeNull();
            sut.Items.Should().NotBeEmpty();
            sut.ToString().Should().Be(id + "-" + customerName);

        }
    }
}
