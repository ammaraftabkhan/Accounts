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
    public interface ICivilLevelServices
    {
        List<CivilLevel> GetAllCivilLevel(FilterModel filter);
        CivilLevel FindCivilLevel(int id);
        bool UpdateCivilLevel(VM_CivilLevel _VM_CivilLevel);
        bool DeleteCivilLevel(int id);
        bool AddCivilLevel(VM_CivilLevel _VM_CivilLevel);
    }
}
