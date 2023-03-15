using Accounts.Common.Virtual_Models;
using Accounts.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Services.Services
{
    public interface IAccountTransDetailServices
    {
        List<AccountTransDetail> GetAllAccountTransDetail();
        AccountTransDetail FindAccountTransDetial(long id);
        bool UpdateAccountTransDetail(VM_AccountTransDetail _VM_AccountTransDetail);
        bool DeleteAccountTransDetail(int id);
        bool AddAccountTransDetail(VM_AccountTransDetail _VM_AccountTransDetail);
    }
}
