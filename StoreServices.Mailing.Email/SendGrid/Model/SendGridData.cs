using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreServices.Mailing.Email.SendGrid.Model
{
    public class SendGridData
    {
        public string SendGridApiKey { get; set; }
        public string EmailTo { get; set; }
        public string NameTo { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}
