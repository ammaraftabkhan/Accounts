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
    public class AccountSubLedgerServices : IAccountSubLedgerServices
    {
        private readonly IAccountSubLedgerRepository _repository;
        public AccountSubLedgerServices(IAccountSubLedgerRepository repository)
        {
            _repository = repository;
        }

        public bool AddAccountSubLedger(VM_AccountSubLedger _VM_AccountsubLedger)
        {
            return _repository.AddAccountSubLedger(_VM_AccountsubLedger);
        }

        public bool DeleteAccountLSubLedger(int id)
        {
            return _repository.DeleteAccountLSubLedger(id);
        }

        public AccountSubLedger FindAccountSubLedger(long id)
        {
            return _repository.FindAccountSubLedger(id);
        }

        public List<dynamic> GetAllAccountSubLedger(FilterModel filter)
        {
            return _repository.GetAllAccountSubLedger(filter);
        }

        public bool UpdateAccountSubLedger(VM_AccountSubLedger _VM_AccountSubLedger)
        {
            return _repository.UpdateAccountSubLedger(_VM_AccountSubLedger);
        }
    }
}
