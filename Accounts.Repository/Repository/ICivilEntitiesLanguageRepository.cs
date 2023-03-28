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
    public interface ICivilEntitiesLanguageRepository
    {
        List<dynamic> GetCivilEntitiesLanguage(FilterModel filter);
        CivilEntitiesLanguage FindCivilEntitiesLanguage(int id);
        bool UpdateCivilEntitiesLanguage(VM_CivilEntitiesLanguage _VM_CivilEntitiesLanguage);
        bool DeleteCivilEntitiesLanguage(int id);
        bool AddCivilEntitiesLanguage(VM_CivilEntitiesLanguage _VM_CivilEntitiesLanguage);
    }
}
