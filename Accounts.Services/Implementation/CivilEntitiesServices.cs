using Accounts.Common.DataTable_Model;
using Accounts.Common.Virtual_Models;
using Accounts.Core.Models;
using Accounts.Repository.Repository;
using Accounts.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Repository.Implementation
{
    public class CivilEntitiesServices : ICivilEntitiesServices
    {
        private readonly ICivilEntitiesRpository _ICivilEntitiesRepository;
        public CivilEntitiesServices(ICivilEntitiesRpository iCivilEntitiesRepository)
        {
            _ICivilEntitiesRepository = iCivilEntitiesRepository;
        }

        public bool AddACivilEntity(VM_CivilEntity _VM_CivilEntity)
        {
            return _ICivilEntitiesRepository.AddACivilEntity(_VM_CivilEntity);
        }

        public bool DeleteCivilEntity(long id)
        {
            return _ICivilEntitiesRepository.DeleteCivilEntity(id);
        }

        public CivilEntity FindCivilEntity(long id)
        {
            return _ICivilEntitiesRepository.FindCivilEntity(id);
        }

        public List<CivilEntity> GetAllCivilEntity(FilterModel filter)
        {
            return _ICivilEntitiesRepository.GetAllCivilEntity(filter);
        }

        public bool UpdateCivilEntity(VM_CivilEntity _VM_CivilEntity)
        {
            return _ICivilEntitiesRepository.UpdateCivilEntity(_VM_CivilEntity);
        }
    }
}
