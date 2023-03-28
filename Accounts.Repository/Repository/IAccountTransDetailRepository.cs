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
    public interface IAccountTransDetailRepository
    {
        List<dynamic> GetAllAccountTransDetail(FilterModel filter);
        AccountTransDetail FindAccountTransDetial(long id);
        bool UpdateAccountTransDetail(VM_AccountTransDetail _VM_AccountTransDetail);
        bool DeleteAccountTransDetail(int id);
        bool AddAccountTransDetail(VM_AccountTransDetail _VM_AccountTransDetail);
    }
}
