using Accounts.Common.DataTable_Model;
using Accounts.Common.Virtual_Models;
using Accounts.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Repository.Repository
{
    public interface ICurrencyServices
    {
        List<Currency> GetAllCurrency(FilterModel filter);
        Currency FindCurrency(int id);
        bool UpdateCurrency(VM_Currency _VM_Currency);
        bool DeleteCurrency(int id);
        bool AddCurrency(VM_Currency _VM_Currency);
    }
}
