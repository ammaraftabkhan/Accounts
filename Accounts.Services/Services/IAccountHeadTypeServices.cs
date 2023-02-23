using Accounts.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Services.Services
{
    public interface IAccountHeadTypeServices
    {
        List<AccountHeadType> GetAccountHeadType();
        AccountHeadType Find(int id);
        bool Update(VM_AccountHeadType _VM_AccountHeadType);
        bool Delete(int id);
        bool Add(VM_AccountHeadType _VM_AccountHeadType);
    }
}
