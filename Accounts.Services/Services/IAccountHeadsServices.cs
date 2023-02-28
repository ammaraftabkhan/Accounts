using Accounts.Common.Virtual_Models;
using Accounts.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Services.Services
{
    public interface IAccountHeadsServices
    {
        List<AccountHead> GetAccountHead();
        AccountHead FindAccountHead(long id);
        bool UpdateAccountHead(VM_AccountHeads _VM_AccountHeads);
        bool DeleteAccountHead(int id);
        bool AddAccountHead(int id, VM_AccountHeads _VM_AccountHeads);
    }
}
