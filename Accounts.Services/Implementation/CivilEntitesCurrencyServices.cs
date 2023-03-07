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
    public class CivilEntitesCurrencyServices : ICivilEntitiesCurrencyServices
    {
        private readonly ICivilEntitesCurrencyRepository _currencyRepository;
        public CivilEntitesCurrencyServices(ICivilEntitesCurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }

        public bool AddCivilEntitiesCurrency(VM_CivilEntitiesCurrency _VM_CivilEntitiesCurrencye)
        {
            return _currencyRepository.AddCivilEntitiesCurrency(_VM_CivilEntitiesCurrencye);        }

        public bool DeleteCivilEntitiesCurrency(int id)
        {
            return _currencyRepository.DeleteCivilEntitiesCurrency(id);
        }

        public CivilEntitiesCurrency FindCivilEntitesCurrency(int id)
        {
            return _currencyRepository.FindCivilEntitesCurrency(id);
        }

        public List<CivilEntitiesCurrency> GetAllCivilEntitesCurrency()
        {
            return _currencyRepository.GetAllCivilEntitesCurrency();
        }

        public bool UpdateCivilEntitiesCurrency(VM_CivilEntitiesCurrency _VM_CivilEntitiesCurrency)
        {
            return _currencyRepository.UpdateCivilEntitiesCurrency(_VM_CivilEntitiesCurrency);
        }
    }
}
