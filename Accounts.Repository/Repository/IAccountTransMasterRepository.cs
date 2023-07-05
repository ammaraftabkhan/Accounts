using Accounts.Common;
using Accounts.Common.DataTable_Model;
using Accounts.Common.Filter_Models;
using Accounts.Common.Virtual_Models;
using Accounts.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Repository.Repository
{
    public interface IAccountTransMasterRepository
    {
        List<dynamic> GetAllAccountTransMaster(FilterModel filter);
        List<dynamic> GetTransDtls(TransactionFilter tFilter);
        Task <VM_AccountTransMaster> FindAccountTransMaster(long id);
        bool UpdateAccountTransMaster(VM_AccountTransMaster _VM_AccountTransMaster);
        Task<bool> DeleteAccountTransMaster(int id);
        Task<bool> AddAccountTransMaster(VM_AccountTransMaster _VM_AccountTransMaster);
    }
}
