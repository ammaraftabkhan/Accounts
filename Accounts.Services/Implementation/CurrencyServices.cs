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
    public class CurrencyServices : ICurrencyServices
    {
        private readonly ICurrencyRepository _currencyRepository;
        public CurrencyServices(ICurrencyRepository currencyRepository) 
        {
            _currencyRepository = currencyRepository;
        }
        public bool AddCurrency(VM_Currency _VM_Currency)
        {
            return _currencyRepository.AddCurrency(_VM_Currency);
        }

        public bool DeleteCurrency(int id)
        {
            return _currencyRepository.DeleteCurrency(id);
        }

        public Currency FindCurrency(int id)
        {
            return _currencyRepository.FindCurrency(id);
        }

        public List<Currency> GetAllCurrency()
        {
            return _currencyRepository.GetAllCurrency();
        }

        public bool UpdateCurrency(VM_Currency _VM_Currency)
        {
            return _currencyRepository.UpdateCurrency(_VM_Currency);
        }
    }
}
