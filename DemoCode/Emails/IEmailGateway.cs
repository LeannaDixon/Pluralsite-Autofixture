using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCode.Emails
{
    public interface IEmailGateway
    {
        void Send(EmailMessage message);
    }
}
