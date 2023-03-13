using Accounts.Common;
using Accounts.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Services.Services
{
    public interface IAccountTransTypeServices
    {
        List<AccountTransType> GetAllAccountTranstype();
        AccountTransType FindAccountTransType(int id);
        bool UpdateAccountTransType(VM_AccountTransType _VM_AccountTransType);
        bool DeleteAccountTransType(int id);
        bool AddAccountTransType(VM_AccountTransType _VM_AccountTransType);
    }
}
