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
    public class AccountProfileServices : IAccountProfileServices
    {
        private readonly IAccountProfileRepository _repository;
        public AccountProfileServices(IAccountProfileRepository repository)
        {
            _repository = repository;
        }

        public bool AddAccountProfile(int id, VM_AccountProfile _VM_AccountProfile)
        {
            return _repository.AddAccountProfile(id,_VM_AccountProfile);
        }

        public bool DeleteAccountProfile(int id)
        {
            return _repository.DeleteAccountProfile(id);
        }

        public AccountProfile FindAccountProfile(long id)
        {
            return _repository.FindAccountProfile(id);
        }

        public List<AccountProfile> GetAllAccountProfile()
        {
            return _repository.GetAllAccountProfile();
        }

        public bool UpdateAccountProfile(VM_AccountProfile _VM_AccountProfile)
        {
            return _repository.UpdateAccountProfile(_VM_AccountProfile);
        }
    }
}