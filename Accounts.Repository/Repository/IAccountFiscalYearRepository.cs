using Accounts.Common.Virtual_Models;
using Accounts.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Repository.Repository
{
    public interface IAccountFiscalYearRepository
    {
        bool AddFiscalYear(VM_AccountFiscalYear _VM_AccountFiscalYear);
        List<AccountFiscalYear> GetAllFiscalYear();
        AccountFiscalYear FindFiscalYear(long id);
        bool UpdateFiscalYear(VM_AccountFiscalYear _VM_AccountFiscalYear);
        bool DeleteFiscalYear(int id);
        
    }
}
