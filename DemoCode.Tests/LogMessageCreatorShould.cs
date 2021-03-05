using AutoFixture;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace DemoCode.Tests
{
    public class LogMessageCreatorShould
    {

        [Test]
        public void CreateASpecificLogMessage()
        {
            // arrange
            var fixture = new Fixture();
            var message = fixture.Create<string>();
            var date = fixture.Create<DateTime>();

            // act
            var sut = LogMessageCreator.Create(message, date);

            // assert
            sut.Should().BeOfType<LogMessage>();
            sut.Message.Should().Be(message);
            sut.Year.Should().Be(date.Year);
        }
    }
}
