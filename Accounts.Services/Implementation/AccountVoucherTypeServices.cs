using Accounts.Common.DataTable_Model;
using Accounts.Common.Virtual_Models;
using Accounts.Core.Models;
using Accounts.Repository.Repository;
using Accounts.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Services.Implementation
{
    public class AccountVoucherTypeServices : IAccountVoucherTypeServices
    {
        private readonly IAccountVoucherTypeRespository _IAccountVoucherTypeRespository;
        public AccountVoucherTypeServices(IAccountVoucherTypeRespository IAccountVoucherTypeRespository)
        {
            _IAccountVoucherTypeRespository = IAccountVoucherTypeRespository;
        }
        public bool AddAccountVoucherType(VM_AccountVoucherType _VM_AccountVoucherType)
        {
            return _IAccountVoucherTypeRespository.AddAccountVoucherType(_VM_AccountVoucherType);
        }

        public bool DeleteAccountVoucherType(int id)
        {
            return _IAccountVoucherTypeRespository.DeleteAccountVoucherType(id);
        }

        public AccountVoucherType FindAccountVoucherType(int id)
        {
           return _IAccountVoucherTypeRespository.FindAccountVoucherType(id);
        }

        public List<dynamic> GetAllAccountVoucherType(FilterModel filter)
        {
            return _IAccountVoucherTypeRespository.GetAllAccountVoucherType(filter);
        }

        public bool UpdateAccountVoucherType(VM_AccountVoucherType _VM_AccountVoucherType)
        {
            return _IAccountVoucherTypeRespository.UpdateAccountVoucherType(_VM_AccountVoucherType);
        }
    }
}
