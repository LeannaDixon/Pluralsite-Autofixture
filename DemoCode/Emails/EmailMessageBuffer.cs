using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DemoCode.Emails
{
    public class EmailMessageBuffer
    {
        private List<EmailMessage> _emails = new List<EmailMessage>();
        private IEmailGateway EmailGateway { get; }

        public int UnsentMessagesCount => _emails.Count;

        public EmailMessageBuffer(IEmailGateway emailGateway)
        {
            EmailGateway = emailGateway;
        }


        public void Add(EmailMessage message)
        {
            _emails.Add(message);
        }

        public void SendAll()
        {
            for (int i = 0; i < _emails.Count; i++)
            {
                var email = _emails[i];

                Send(email);
                _emails.Remove(email);
            }
        }

        public void SendLimited(int maximumMessagesToSend)
        {
            var limitedBatchOfMessages = _emails.Take(maximumMessagesToSend).ToArray();

            for (int i = 0; i < limitedBatchOfMessages.Length; i++)
            {
                var email = limitedBatchOfMessages[i];
                Send(email);
                _emails.Remove(email);
            }
        }

        private void Send(EmailMessage email)
        {
            EmailGateway.Send(email);
        }
    }
}
    

