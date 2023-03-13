using Accounts.Common.Virtual_Models;
using Accounts.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Repository.Repository
{
    public interface ICivilEntitiesRpository
    {
        List<CivilEntity> GetAllCivilEntity();
        CivilEntity FindCivilEntity(long id);
        bool UpdateCivilEntity(VM_CivilEntity _VM_CivilEntity);
        bool DeleteCivilEntity(long id);
        bool AddACivilEntity(VM_CivilEntity _VM_CivilEntity);
    }
}
