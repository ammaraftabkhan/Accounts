using Accounts.Common.Virtual_Models;
using Accounts.Core.Models;
using Accounts.Repository.Repository;
using Accounts.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Services.Implementation
{
    public class AccountFiscalYearServices : IAccountFiscalYearServices
    {
        private readonly IAccountFiscalYearRepository _accountFiscalYearRepository;
        public AccountFiscalYearServices(IAccountFiscalYearRepository accountFiscalYearRepository)
        {
            _accountFiscalYearRepository = accountFiscalYearRepository;
        }
        public bool AddFiscalYear(VM_AccountFiscalYear _VM_AccountFiscalYear)
        {
            return _accountFiscalYearRepository.AddFiscalYear(_VM_AccountFiscalYear);
        }

        public bool DeleteFiscalYear(int id)
        {
            return _accountFiscalYearRepository.DeleteFiscalYear(id);
        }

        public AccountFiscalYear FindFiscalYear(long id)
        {
            return _accountFiscalYearRepository.FindFiscalYear(id);
        }

        public List<AccountFiscalYear> GetAllFiscalYear()
        {
            return _accountFiscalYearRepository.GetAllFiscalYear();
        }

        public bool UpdateFiscalYear(VM_AccountFiscalYear _VM_AccountFiscalYear)
        {
            return _accountFiscalYearRepository.UpdateFiscalYear(_VM_AccountFiscalYear);
        }
    }
}
