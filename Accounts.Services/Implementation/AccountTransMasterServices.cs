﻿using Accounts.Common.Virtual_Models;
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

        public bool AddAccountTransMaster(VM_AccountTransMaster _VM_AccountTransMaster)
        {
            return _repository.AddAccountTransMaster(_VM_AccountTransMaster);
        }

        public bool DeleteAccountTransMaster(int id)
        {
            return _repository.DeleteAccountTransMaster(id);
        }

        public AccountTransMaster FindAccountTransMaster(int id)
        {
            return _repository.FindAccountTransMaster(id);
        }

        public List<AccountTransMaster> GetAllAccountTransMaster()
        {
            return _repository.GetAllAccountTransMaster();
        }

        public bool UpdateAccountTransMaster(VM_AccountTransMaster _VM_AccountTransMaster)
        {
            return _repository.UpdateAccountTransMaster(_VM_AccountTransMaster);
        }
    }
}