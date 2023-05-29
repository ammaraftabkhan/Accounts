using Accounts.Common.DataTable_Model;
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
        List<dynamic> GetAllAccountProfile(FilterModel filter);
        AccountProfile FindAccountProfile(long id);
        bool UpdateAccountProfile(VM_AccountProfile _VM_AccountProfile);
        bool DeleteAccountProfile(int id);
        long AddAccountProfile(VM_AccountProfile _VM_AccountProfile);
    }
}
