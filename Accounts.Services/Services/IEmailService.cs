using Accounts.Common.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Services.Services
{
    public interface IEmailService
    {
        void SendEmail(Message message);
    }
}
