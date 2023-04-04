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
    public interface IAccountVoucherTypeServices
    {
        List<dynamic> GetAllAccountVoucherType(FilterModel filter);
        AccountVoucherType FindAccountVoucherType(int id);
        bool UpdateAccountVoucherType(VM_AccountVoucherType _VM_AccountVoucherType);
        bool DeleteAccountVoucherType(int id);
        bool AddAccountVoucherType(VM_AccountVoucherType _VM_AccountVoucherType);
    }
}
