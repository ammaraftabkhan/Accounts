using Accounts.Common;
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
    public class AccountTransTypeServices : IAccountTransTypeServices
    {
        private readonly IAccountTransTypeRepository _repository;
        public AccountTransTypeServices(IAccountTransTypeRepository repository)
        {
            _repository = repository;
        }

        public bool AddAccountTransType(VM_AccountTransType _VM_AccountTransType)
        {
            return _repository.AddAccountTransType(_VM_AccountTransType);
        }

        public bool DeleteAccountTransType(int id)
        {
            return _repository.DeleteAccountTransType(id);
        }

        public AccountTransType FindAccountTransType(int id)
        {
            return _repository.FindAccountTransType(id);
        }

        public List<AccountTransType> GetAllAccountTranstype()
        {
            return _repository.GetAllAccountTranstype();
        }

        public bool UpdateAccountTransType(VM_AccountTransType _VM_AccountTransType)
        {
            return _repository.UpdateAccountTransType(_VM_AccountTransType);
        }
    }
}
