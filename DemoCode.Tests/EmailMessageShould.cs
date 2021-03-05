using NUnit.Framework;
using AutoFixture;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using DemoCode.Emails;
using Moq;
using AutoFixture.AutoMoq;
using AutoFixture.NUnit3;

namespace DemoCode.Tests
{
    public class EmailMessageShould
    {
        private EmailMessage EmailMessage1;
        private EmailMessage EmailMessage2;
        private EmailMessage EmailMessage3;
        private Mock<IEmailGateway> MockEmailGateway;
        private EmailMessageBuffer SUT;

        [SetUp]
        public void SetUp()
        {
            // ************ AutoFixture.AutoMoq: This AutoMoqCustomization now can create Moq Interfaces! So we no longer need to create a Moq IEmailGateway.
            var fixture = new Fixture()
                .Customize(new AutoMoqCustomization());
            EmailMessage1 = fixture.Create<EmailMessage>();
            EmailMessage2 = fixture.Create<EmailMessage>();
            EmailMessage3 = fixture.Create<EmailMessage>();

            // ********** Now we freeze this so that the IEmailGateway is always the same, now we can use .Verify() on it.
            MockEmailGateway = fixture
                .Freeze<Mock<IEmailGateway>>();

            SUT = fixture.Create<EmailMessageBuffer>();

        }
        [Test]
        public void AddMessageToBuffer()
        {
            
            SUT.Add(EmailMessage1);
            SUT.UnsentMessagesCount.Should().Be(1);
        }


        [Test]
        public void RemoveMessageFromBufferWhenSent()
        {

            SUT.Add(EmailMessage1);
            SUT.SendAll();

            SUT.UnsentMessagesCount.Should().Be(0);
        }


        [Test]
        public void SendOnlySpecifiedNumberOfMessages()
        {

            SUT.Add(EmailMessage1);
            SUT.Add(EmailMessage2);
            SUT.Add(EmailMessage3);

            SUT.SendLimited(2);
            SUT.UnsentMessagesCount.Should().Be(1);
        }

        [Test]
        public void SendOnlyCalledOnce()
        {

            SUT.Add(EmailMessage1);
            SUT.SendAll();

            MockEmailGateway.Verify(method => method.Send(It.IsAny<EmailMessage>()), times: Times.Once);
        }

        [AutoMoqData]
        [Test]
        public void SendEmailToGateway_AutoMoq(EmailMessage message,
                                               [Frozen] Mock<IEmailGateway> mockGateway,
                                               EmailMessageBuffer sut)
        {
            // arrange
            sut.Add(message);

            // act
            sut.SendAll();

            // assert
            mockGateway.Verify(x => x.Send(It.IsAny<EmailMessage>()), Times.Once());
        }

    }
}
