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
    public class AccountTransMasterServices : IAccountTransMasterServices
    {
        private readonly IAccountTransMasterRepository _repository;
        public AccountTransMasterServices(IAccountTransMasterRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddAccountTransMaster(VM_AccountTransMaster _VM_AccountTransMaster)
        {
            return await _repository.AddAccountTransMaster(_VM_AccountTransMaster);
        }

        public async Task<bool> DeleteAccountTransMaster(int id)
        {
            return await _repository.DeleteAccountTransMaster(id);
        }

        public async Task<VM_AccountTransMaster> FindAccountTransMaster(long id)
        {
            return await _repository.FindAccountTransMaster(id);
        }

        public List<dynamic> GetAllAccountTransMaster(FilterModel filter)
        {
            return _repository.GetAllAccountTransMaster(filter);
        }

        public bool UpdateAccountTransMaster(VM_AccountTransMaster _VM_AccountTransMaster)
        {
            return _repository.UpdateAccountTransMaster(_VM_AccountTransMaster);
        }
    }
}
