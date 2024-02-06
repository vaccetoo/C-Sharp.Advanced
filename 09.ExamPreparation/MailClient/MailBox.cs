using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailClient
{
    public class MailBox
    {
        public MailBox(int capacity)
        {
            Capacity = capacity;
            Inbox = new List<Mail>();
            Archive = new List<Mail>();
        }

        public int Capacity { get; set; }

        public List<Mail> Inbox { get; set; }

        public List<Mail> Archive { get; set; }

        public void IncomingMail(Mail mail)
        {
            if (Inbox.Count < Capacity)
            {
                Inbox.Add(mail);
            }
        }

        public bool DeleteMail(string sender)
        {
            if (Inbox.Any(s => s.Sender == sender))
            {
                Inbox.RemoveAll(s => s.Sender == sender);
                return true;
            }

            return false;
        }

        public int ArchiveInboxMessages()
        {
            foreach (Mail mail in Inbox)
            {
                Archive.Add(mail);
            }

            Inbox.Clear();
            return Archive.Count;
        }

        public string GetLongestMessage()
        {
            return Inbox.OrderByDescending(b => b.Body).First().ToString();
        }

        public string InboxView()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Inbox:");
            
            foreach (Mail mail in Inbox)
            {
                sb.AppendLine($"From: {mail.Sender} / To: {mail.Receiver}");
                sb.AppendLine($"Message: {mail.Body}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
