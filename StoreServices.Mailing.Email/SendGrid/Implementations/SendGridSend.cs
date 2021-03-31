using SendGrid;
using SendGrid.Helpers.Mail;
using StoreServices.Mailing.Email.SendGrid.Interfaces;
using StoreServices.Mailing.Email.SendGrid.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreServices.Mailing.Email.SendGrid.Implementations
{
    public class SendGridSend : ISendGridSend
    {       
        public async Task<(bool result, string errorMessage)> SendEmail(SendGridData data)
        {
            try
            {
                var sendGridClient = new SendGridClient(data.SendGridApiKey);
                var to = new EmailAddress(data.EmailTo, data.NameTo);
                var subject = data.Subject;
                var sender = new EmailAddress("jorge_moreno_rodriguez@hotmail.com", "RabbitMQ"); ;
                var content = data.Content;

                var objMessage = MailHelper.CreateSingleEmail(sender, to, subject, content, content);

                var response = await sendGridClient.SendEmailAsync(objMessage);

                return (true, null);
            }
            catch (Exception e )
            {
                return (false, e.Message);
            }
        }
    }
}
