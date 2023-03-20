using Accounts.Common.DataTable_Model;
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
    public class AccountHeadTypeServices : IAccountHeadTypeServices
    {
        private readonly IAccountHeadTypeRepository accountHeadTypeRepository;

        public AccountHeadTypeServices(IAccountHeadTypeRepository accountHeadTypeRepository)
        {
            this.accountHeadTypeRepository = accountHeadTypeRepository;
        }

        public bool Add(VM_AccountHeadType _VM_AccountHeadType)
        {
            return accountHeadTypeRepository.Add(_VM_AccountHeadType);
        }

        public bool Delete(int id)
        {
            return accountHeadTypeRepository.Delete(id);
        }

        public AccountHeadType Find(int id)
        {
            return accountHeadTypeRepository.Find(id);
        }

        public List<VM_AccountHeadType> GetAccountHeadType(FilterModel filter)
        {
            return accountHeadTypeRepository.GetAccountHeadType(filter);
        }

        public bool Update(VM_AccountHeadType _VM_AccountHeadType)
        {
            return accountHeadTypeRepository.Update(_VM_AccountHeadType);
        }
    }
}
