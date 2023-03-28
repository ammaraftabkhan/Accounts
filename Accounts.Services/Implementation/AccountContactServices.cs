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

namespace Accounts.Services.Implementation
{
    public class AccountContactServices : IAccountContactServices
    {
        private readonly IAccountsContactRepository _accountsContactRepository;
        public AccountContactServices(IAccountsContactRepository accountsContactRepository)
        {
            _accountsContactRepository = accountsContactRepository;
        }

        public bool AddAccountContact(VM_AccountContact _VM_AccountContact)
        {
            return _accountsContactRepository.AddAccountContact(_VM_AccountContact);
        }

        public bool DeleteAccountContact(int id)
        {
            return _accountsContactRepository.DeleteAccountContact(id);
        }

        public AccountContact FindAccountContact(long id)
        {
            return _accountsContactRepository.FindAccountContact(id);
        }

        public List<dynamic> GetAllAccountContact(FilterModel filter)
        {
            return _accountsContactRepository.GetAllAccountContact(filter);
        }

        public bool UpdateAccountContact(VM_AccountContact _VM_AccountContact)
        {
            return _accountsContactRepository.UpdateAccountContact(_VM_AccountContact);
        }
    }
}
