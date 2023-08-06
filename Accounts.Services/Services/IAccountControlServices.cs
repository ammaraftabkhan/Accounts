using Accounts.Common.DataTable_Model;
using Accounts.Common.Response_Model;
using Accounts.Common.Virtual_Models;
using Accounts.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Services.Services
{
    public interface IAccountControlServices
    {
        ServiceResultDTO GetAllAccountControl(FilterModel filter);
        AccountControl FindAccountControl(long id);
        ServiceResultDTO UpdateAccountControl(VM_AccountControl _VM_AccountControl);
        ServiceResultDTO DeleteAccountControl(int id);
        bool AddAccountControl(VM_AccountControl _VM_AccountControl);
    }
}
