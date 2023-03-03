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
    public class AccountContactServices : IAccountContactServices
    {
        private readonly IAccountsContactRepository _accountsContactRepository;
        public AccountContactServices(IAccountsContactRepository accountsContactRepository)
        {
            _accountsContactRepository = accountsContactRepository;
        }

        public bool AddAccountContact(int id, VM_AccountContact _VM_AccountContact)
        {
            return _accountsContactRepository.AddAccountContact(id,_VM_AccountContact);
        }

        public bool DeleteAccountContact(int id)
        {
            return _accountsContactRepository.DeleteAccountContact(id);
        }

        public AccountContact FindAccountContact(long id)
        {
            return _accountsContactRepository.FindAccountContact(id);
        }

        public List<AccountContact> GetAllAccountContact()
        {
            return _accountsContactRepository.GetAllAccountContact();
        }

        public bool UpdateAccountContact(VM_AccountContact _VM_AccountContact)
        {
            return _accountsContactRepository.UpdateAccountContact(_VM_AccountContact);
        }
    }
}
