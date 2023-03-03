using Accounts.Common.Virtual_Models;
using Accounts.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Services.Services
{
    public interface IAccountContactServices
    {
        List<AccountContact> GetAllAccountContact();
        AccountContact FindAccountContact(long id);
        bool UpdateAccountContact(VM_AccountContact _VM_AccountContact);
        bool DeleteAccountContact(int id);
        bool AddAccountContact(int id, VM_AccountContact _VM_AccountContact);
    }
}
