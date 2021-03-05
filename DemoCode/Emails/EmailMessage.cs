using System;

namespace DemoCode.Emails
{
    public class EmailMessage
    {
        private string _somePrivateField;

        public string SomePublicField;
        private string SomePrivateProperty { get; set; }
        public Guid Id { get; set; }
        public string ToAddress { get; private set; }
        public string MessageBody { get; private set; }
        public string Subject { get; private set; }
        public bool IsImportant { get; private set; }

        public EmailMessageType MessageType { get; set; }

        public EmailMessage(string toAddress, string messageBody, bool isImportant, string subject)
        {
            ToAddress = toAddress;
            MessageBody = messageBody;
            IsImportant = isImportant;
            Subject = subject;
        }
    }
}