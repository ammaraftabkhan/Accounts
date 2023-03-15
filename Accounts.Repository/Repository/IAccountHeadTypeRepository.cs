using Accounts.Common.DataTable_Model;
using Accounts.Core.Context;
using Accounts.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Repository.Repository
{
    public interface IAccountHeadTypeRepository
    {
        List <AccountHeadType> GetAccountHeadType(FilterModel filter);
        AccountHeadType Find(int id);
        bool Update(VM_AccountHeadType _VM_AccountHeadType);
        bool Delete(int id);
        bool Add(VM_AccountHeadType _VM_AccountHeadType);
    }
}
