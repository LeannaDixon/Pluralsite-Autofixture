using AutoFixture;
using FluentAssertions;
using NUnit.Framework;

namespace DemoCode.Tests
{
    public class NameJoinerShould
    {

        [Test]
        public void BasicStrings()
        {
            // assert
            var sut = new NameJoiner();
            var fixture = new Fixture();

            var firstName = fixture.Create<string>();
            var lastName = fixture.Create<string>();

            // act
            sut.Join(firstName, lastName);

            // asert
            sut.Join(firstName, lastName).Should().BeEquivalentTo(firstName + ' ' + lastName);
        }
    }
}
