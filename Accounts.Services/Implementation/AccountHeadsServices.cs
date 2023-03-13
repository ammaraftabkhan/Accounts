using Accounts.Common.Virtual_Models;
using Accounts.Core.Models;
using Accounts.Repository.Implementation;
using Accounts.Repository.Repository;
using Accounts.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Services.Implementation
{
    public class AccountHeadsServices : IAccountHeadsServices
    {
         private readonly IAccountHeadsRepository  accountHeadsRepository;
        public AccountHeadsServices(IAccountHeadsRepository accountHeadsRepository)
        {
            this.accountHeadsRepository = accountHeadsRepository;
        }

        public bool AddAccountHead(int id, VM_AccountHeads _VM_AccountHeads)
        {
            return accountHeadsRepository.AddAccountHead(id, _VM_AccountHeads);

        }

       

        public bool DeleteAccountHead(int id)
        {
            return accountHeadsRepository.DeleteAccountHead(id);
        }

        public AccountHead FindAccountHead(long id)
        {
            return accountHeadsRepository.FindAccountHead(id);
        }

       

        public List<AccountHead> GetAccountHead()
        {
            return accountHeadsRepository.GetAccountHead();
        }

        public bool UpdateAccountHead(VM_AccountHeads _VM_AccountHeads)
        {
            return accountHeadsRepository.UpdateAccountHead(_VM_AccountHeads);
        }

       
    }
}
