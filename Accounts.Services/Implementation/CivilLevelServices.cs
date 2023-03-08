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
    public class CivilLevelServices : ICivilLevelServices
    {
        private readonly ICivilLevelRepository _repository;
        public CivilLevelServices(ICivilLevelRepository repository) 
        {
            _repository = repository;
        }
        public bool AddCivilLevel(VM_CivilLevel _VM_CivilLevel)
        {
            return _repository.AddCivilLevel(_VM_CivilLevel);
        }

        public bool DeleteCivilLevel(int id)
        {
            return _repository.DeleteCivilLevel(id);
        }

        public CivilLevel FindCivilLevel(int id)
        {
            return _repository.FindCivilLevel(id);
        }

        public List<CivilLevel> GetAllCivilLevel()
        {
            return _repository.GetAllCivilLevel();
        }

        public bool UpdateCivilLevel(VM_CivilLevel _VM_CivilLevel)
        {
            return _repository.UpdateCivilLevel(_VM_CivilLevel);
        }
    }
}
