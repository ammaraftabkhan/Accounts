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
    public interface IAccountFiscalYearServices
    {
        bool AddFiscalYear(VM_AccountFiscalYear _VM_AccountFiscalYear);
        List<dynamic> GetAllFiscalYear(FilterModel filter);
        AccountFiscalYear FindFiscalYear(long id);
        bool UpdateFiscalYear(VM_AccountFiscalYear _VM_AccountFiscalYear);
        bool DeleteFiscalYear(int id);
    }
}
