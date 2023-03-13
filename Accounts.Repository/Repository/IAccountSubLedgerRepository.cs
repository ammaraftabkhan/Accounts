using Accounts.Common.Virtual_Models;
using Accounts.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Repository.Repository
{
    public interface IAccountSubLedgerRepository
    {
        List<AccountSubLedger> GetAllAccountSubLedger();
        AccountSubLedger FindAccountSubLedger(long id);
        bool UpdateAccountSubLedger(VM_AccountSubLedger _VM_AccountSubLedger);
        bool DeleteAccountLSubLedger(int id);
        bool AddAccountSubLedger(VM_AccountSubLedger _VM_AccountsubLedger);
    }
}
