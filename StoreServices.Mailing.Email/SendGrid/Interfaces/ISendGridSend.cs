using StoreServices.Mailing.Email.SendGrid.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreServices.Mailing.Email.SendGrid.Interfaces
{
    public interface ISendGridSend
    {
        Task<(bool result, string errorMessage)> SendEmail(SendGridData data);
    }
}
