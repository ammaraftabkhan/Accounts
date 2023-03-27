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
    public interface ICivilEntitesCurrencyRepository
    {
        List<CivilEntitiesCurrency> GetAllCivilEntitesCurrency(FilterModel filter);
        CivilEntitiesCurrency FindCivilEntitesCurrency(int id);
        bool UpdateCivilEntitiesCurrency(VM_CivilEntitiesCurrency _VM_CivilEntitiesCurrency);
        bool DeleteCivilEntitiesCurrency(int id);
        bool AddCivilEntitiesCurrency(VM_CivilEntitiesCurrency _VM_CivilEntitiesCurrencye);
    }
}
