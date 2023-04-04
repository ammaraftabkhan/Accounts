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
    public class AccountVoucherMasterServices : IAccountVoucherMasterServices
    {
        private readonly IAccountVoucherMasterRepository _IAccountVoucherMasterRepository;
        public AccountVoucherMasterServices(IAccountVoucherMasterRepository iAccountVoucherMasterRepository)
        {
            _IAccountVoucherMasterRepository = iAccountVoucherMasterRepository;
        }

        public bool AddAccountVoucherMaster(VM_AccountVoucherMaster _VM_AccountVoucherMaster)
        {
            return _IAccountVoucherMasterRepository.AddAccountVoucherMaster(_VM_AccountVoucherMaster);
        }

        public bool DeleteAccountVoucherMaster(int id)
        {
            return _IAccountVoucherMasterRepository.DeleteAccountVoucherMaster(id);
        }

        public AccountVoucherMaster FindAccountVoucherMaster(int id)
        {
            return _IAccountVoucherMasterRepository.FindAccountVoucherMaster(id);
        }

        public List<dynamic> GetAllAccountVoucherMaster(FilterModel filter)
        {
            return _IAccountVoucherMasterRepository.GetAllAccountVoucherMaster(filter);
        }

        public bool UpdateAccountVoucherMaster(VM_AccountVoucherMaster _VM_AccountVoucherMaster)
        {
            return _IAccountVoucherMasterRepository.UpdateAccountVoucherMaster(_VM_AccountVoucherMaster);
        }
    }
}
