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
    public class LanguageServices : ILanguageServices
    {
        private readonly ILanguageRepository _languageRepository;
        public LanguageServices(ILanguageRepository languageRepository) 
        {
            _languageRepository = languageRepository;
        }
        public bool AddLanguage(VM_Language _VM_Language)
        {
            return _languageRepository.AddLanguage(_VM_Language);
        }

        public bool DeleteLanguage(int id)
        {
            return _languageRepository.DeleteLanguage(id);
        }

        public Language FindLanguage(int id)
        {
            return _languageRepository.FindLanguage(id);
        }

        public List<Language> GetAllLanguage(FilterModel filter)
        {
            return _languageRepository.GetAllLanguage(filter);
        }

        public bool UpdateLanguage(VM_Language _VM_Language)
        {
            return _languageRepository.UpdateLanguage(_VM_Language);
        }
    }
}
