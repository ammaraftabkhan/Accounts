using Accounts.Common.DataTable_Model;
using Accounts.Common.Virtual_Models;
using Accounts.Core.Models;
using Accounts.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Repository.Implementation
{
    public class CivilEntitesLanguageServices : ICivilEntitiesLanguageServices
    {
        private readonly ICivilEntitiesLanguageRepository _languageRepository;
        public CivilEntitesLanguageServices(ICivilEntitiesLanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public bool AddCivilEntitiesLanguage(VM_CivilEntitiesLanguage _VM_CivilEntitiesLanguage)
        {
            return _languageRepository.AddCivilEntitiesLanguage(_VM_CivilEntitiesLanguage);
        }

        public bool DeleteCivilEntitiesLanguage(int id)
        {
            return _languageRepository.DeleteCivilEntitiesLanguage(id);
        }

        public CivilEntitiesLanguage FindCivilEntitiesLanguage(int id)
        {
            return _languageRepository.FindCivilEntitiesLanguage(id);
        }

        public List<CivilEntitiesLanguage> GetCivilEntitiesLanguage(FilterModel filter)
        {
            return _languageRepository.GetCivilEntitiesLanguage(filter);
        }

        public bool UpdateCivilEntitiesLanguage(VM_CivilEntitiesLanguage _VM_CivilEntitiesLanguage)
        {
            return _languageRepository.UpdateCivilEntitiesLanguage(_VM_CivilEntitiesLanguage);
        }
    }
}
