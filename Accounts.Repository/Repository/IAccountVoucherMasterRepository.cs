using Accounts.Common.DataTable_Model;
using Accounts.Common.Virtual_Models;
using Accounts.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Repository.Repository
{
    public interface IAccountVoucherMasterRepository
    {
        List<dynamic> GetAllAccountVoucherMaster(FilterModel filter);
        AccountVoucherMaster FindAccountVoucherMaster(int id);
        bool UpdateAccountVoucherMaster(VM_AccountVoucherMaster _VM_AccountVoucherMaster);
        bool DeleteAccountVoucherMaster(int id);
        bool AddAccountVoucherMaster(VM_AccountVoucherMaster _VM_AccountVoucherMaster);
    }
}
