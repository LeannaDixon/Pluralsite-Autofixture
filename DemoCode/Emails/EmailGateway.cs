using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DemoCode.Emails
{
    public class EmailGateway : IEmailGateway
    {
        public void Send(EmailMessage message)
        {
            Debug.WriteLine("Sending email to: " + message.ToAddress);
        }
    }
}
