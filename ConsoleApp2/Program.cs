using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public interface IMailConstructor
    {
        IMailConstructor AddRecipient(string recipient);
        IMailConstructor AddSubject(string subject);
        IMailConstructor AddContent(string content);
        IMailConstructor AddAttachment(string attachment);
        IMailConstructor Reset();
        Mail Construct();
    }
    public class Mail
    {
        public string Subject { get; set; }
        public string Content { get; set; }
        public string Recipient { get; set; }
        public string Attachments { get; set; }
    }

    public class MailConstructor : IMailConstructor
    {
        Mail mail;
        public MailConstructor()
        {
            mail = new Mail();
        }
        public IMailConstructor AddRecipient(string recipient)
        {
            mail.Recipient = recipient;
            return this;
        }
        public IMailConstructor AddSubject(string subject)
        {
            mail.Subject = subject;
            return this;
        }
        public IMailConstructor AddAttachment(string attachment)
        {
            mail.Attachments = attachment;
            return this;
        }
        public IMailConstructor AddContent(string content)
        {
            mail.Content = content;
            return this;
        }
        public Mail Construct()
        {
            return mail;
        }
        public IMailConstructor Reset()
        {
            mail = new Mail();
            return this;
        }
    }

    public class SMTP
    {
        IMailConstructor mailConstructor;
        public SMTP(IMailConstructor mailConstructor)
        {
            this.mailConstructor = mailConstructor;
        }

        public void SendNoReplyMail()
        {
             mailConstructor.AddSubject("No Reply").AddContent("Hello World").Construct();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            SMTP smtp = new SMTP(new MailConstructor());
            smtp.SendNoReplyMail();
        }
    }
}
