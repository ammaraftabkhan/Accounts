using Accounts.Common.Virtual_Models;
using Accounts.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Services.Services
{
    public interface IAccountProfileServices
    {
        List<AccountProfile> GetAllAccountProfile();
        AccountProfile FindAccountProfile(long id);
        bool UpdateAccountProfile(VM_AccountProfile _VM_AccountProfile);
        bool DeleteAccountProfile(int id);
        bool AddAccountProfile(VM_AccountProfile _VM_AccountProfile);
    }
}
