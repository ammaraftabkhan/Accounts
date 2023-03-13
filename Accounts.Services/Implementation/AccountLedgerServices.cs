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
    public class AccountLedgerServices : IAccountLedgerServices
    {
        private readonly IAccountLedgerRepository _accountLedgerRepository;
        public AccountLedgerServices(IAccountLedgerRepository accountLedgerRepository)
        {
            _accountLedgerRepository = accountLedgerRepository;
        }

        public bool AddAccountLedger(VM_AccountLedger _VM_AccountLedger)
        {
            return _accountLedgerRepository.AddAccountLedger(_VM_AccountLedger);
        }

        public bool DeleteAccountLedger(int id)
        {
            return _accountLedgerRepository.DeleteAccountLedger(id);
        }

        public AccountLedger FindAccountLedger(long id)
        {
            return _accountLedgerRepository.FindAccountLedger(id);
        }

        public List<AccountLedger> GetAllAccountLedger()
        {
            return _accountLedgerRepository.GetAllAccountLedger();
        }

        public bool UpdateAccountLegder(VM_AccountLedger _VM_AccountLedger)
        {
            return _accountLedgerRepository.UpdateAccountLedger(_VM_AccountLedger);
        }
    }
}
