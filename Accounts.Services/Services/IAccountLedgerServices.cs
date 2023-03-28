using Accounts.Common.DataTable_Model;
using Accounts.Common.Virtual_Models;
using Accounts.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Services.Services
{
    public interface IAccountLedgerServices
    {
        List<dynamic> GetAllAccountLedger(FilterModel filter);
        AccountLedger FindAccountLedger(long id);
        bool UpdateAccountLegder(VM_AccountLedger _VM_AccountLedger);
        bool DeleteAccountLedger(int id);
        bool AddAccountLedger(VM_AccountLedger _VM_AccountLedger);
    }
}
