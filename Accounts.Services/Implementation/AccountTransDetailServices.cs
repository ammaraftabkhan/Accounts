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
    public class AccountTransDetailServices : IAccountTransDetailServices
    {
        private readonly IAccountTransDetailRepository _repository;
        public AccountTransDetailServices(IAccountTransDetailRepository repository)
        {
            _repository = repository;
        }

        public bool AddAccountTransDetail(VM_AccountTransDetail _VM_AccountTransDetail)
        {
            return _repository.AddAccountTransDetail(_VM_AccountTransDetail);
        }

        public bool DeleteAccountTransDetail(int id)
        {
            return _repository.DeleteAccountTransDetail(id);
        }

        public AccountTransDetail FindAccountTransDetial(long id)
        {
            return _repository.FindAccountTransDetial(id);
        }

        public List<dynamic> GetAllAccountTransDetail(FilterModel filter)
        {
            return _repository.GetAllAccountTransDetail(filter);
        }

        public bool UpdateAccountTransDetail(VM_AccountTransDetail _VM_AccountTransDetail)
        {
            return _repository.UpdateAccountTransDetail(_VM_AccountTransDetail);
        }
    }
}
