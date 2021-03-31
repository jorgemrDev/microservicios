using StoreServices.RabbitMQ.Bus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreServices.RabbitMQ.Bus.EventQueue
{
    public class EmailEventQueue : Event
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public EmailEventQueue(string to, string subject, string content)
        {
            To = to;
            Subject = subject;
            Content = content;
        }
    }
}
