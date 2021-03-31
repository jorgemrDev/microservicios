using Microsoft.Extensions.Logging;
using StoreServices.Mailing.Email.SendGrid.Interfaces;
using StoreServices.Mailing.Email.SendGrid.Model;
using StoreServices.RabbitMQ.Bus.EventQueue;
using StoreServices.RabbitMQ.Bus.RabbitBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreServices.Api.Author.RabbitHandler
{
    public class EmailEventHandler : IEventHandler<EmailEventQueue>
    {
        private readonly ILogger<EmailEventHandler> _logger;
        private readonly ISendGridSend _sendGridSend;
        private readonly Microsoft.Extensions.Configuration.IConfiguration _conf;

        public EmailEventHandler(ILogger<EmailEventHandler> logger,
            ISendGridSend sendGridSend,
            Microsoft.Extensions.Configuration.IConfiguration conf)
        {
            _logger = logger;
            _sendGridSend = sendGridSend;
            _conf = conf;
        }

        public EmailEventHandler()
        {

        }
        public async Task Handle(EmailEventQueue @event)
        {
            _logger.LogInformation($"Message from RabbitMQ { @event.Subject }");
            var objData = new SendGridData();
            objData.Content = @event.Content;
            objData.EmailTo = @event.To;
            objData.NameTo = @event.To;
            objData.Subject = @event.Subject;
            objData.SendGridApiKey = _conf["SendGrid:ApiKey"];
           var result = await _sendGridSend.SendEmail(objData);
            if (result.result)
            {
                await Task.CompletedTask;
                return;
            } 
           
        }
    }
}
