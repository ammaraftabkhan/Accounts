using Accounts.Common;
using Accounts.Common.Virtual_Models;
using Accounts.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Repository.Repository
{
    public interface IAccountTransTypeRepository
    {
        List<AccountTransType> GetAllAccountTranstype();
        AccountTransType FindAccountTransType(int id);
        bool UpdateAccountTransType(VM_AccountTransType _VM_AccountTransType);
        bool DeleteAccountTransType(int id);
        bool AddAccountTransType(VM_AccountTransType _VM_AccountTransType);
    }
}
