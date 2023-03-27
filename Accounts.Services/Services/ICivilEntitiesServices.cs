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
    public interface ICivilEntitiesServices
    {
        List<CivilEntity> GetAllCivilEntity(FilterModel filter);
        CivilEntity FindCivilEntity(long id);
        bool UpdateCivilEntity(VM_CivilEntity _VM_CivilEntity);
        bool DeleteCivilEntity(long id);
        bool AddACivilEntity(VM_CivilEntity _VM_CivilEntity);
    }
}
