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
    public interface IAccountSubLedgerServices
    {
        List<dynamic> GetAllAccountSubLedger(FilterModel filter);
        AccountSubLedger FindAccountSubLedger(long id);
        bool UpdateAccountSubLedger(VM_AccountSubLedger _VM_AccountSubLedger);
        bool DeleteAccountLSubLedger(int id);
        bool AddAccountSubLedger(VM_AccountSubLedger _VM_AccountsubLedger);
    }
}
