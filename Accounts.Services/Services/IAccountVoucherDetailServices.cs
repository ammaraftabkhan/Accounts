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
    public interface IAccountVoucherDetailServices
    {
        List<dynamic> GetAllAccountVoucherDetail(FilterModel filter);
        AccountVoucherDetail FindAccountVoucherDetail(int id);
        bool UpdateAccountVoucherDetail(VM_AccountVoucherDetail _VM_AccountVoucherDetail);
        bool DeleteAccountVoucherDetail(int id);
        bool AddAccountVoucherDetail(VM_AccountVoucherDetail _VM_AccountVoucherDetail);
    }
}
