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
    public class AccountVoucherDetailServices : IAccountVoucherDetailServices
    {
        private readonly IAccountVoucherDetailRepository _IAccountVoucherDetailRepository;
        public AccountVoucherDetailServices(IAccountVoucherDetailRepository iAccountVoucherDetailRepository)
        {
            _IAccountVoucherDetailRepository = iAccountVoucherDetailRepository;
        }

        public bool AddAccountVoucherDetail(VM_AccountVoucherDetail _VM_AccountVoucherDetail)
        {
            return _IAccountVoucherDetailRepository.AddAccountVoucherDetail(_VM_AccountVoucherDetail);
        }

        public bool DeleteAccountVoucherDetail(int id)
        {
            return _IAccountVoucherDetailRepository.DeleteAccountVoucherDetail(id);
        }

        public AccountVoucherDetail FindAccountVoucherDetail(int id)
        {
            return _IAccountVoucherDetailRepository.FindAccountVoucherDetail(id);
        }

        public List<dynamic> GetAllAccountVoucherDetail(FilterModel filter)
        {
            return _IAccountVoucherDetailRepository.GetAllAccountVoucherDetail(filter);
        }

        public bool UpdateAccountVoucherDetail(VM_AccountVoucherDetail _VM_AccountVoucherDetail)
        {
            return _IAccountVoucherDetailRepository.UpdateAccountVoucherDetail(_VM_AccountVoucherDetail);
        }
    }
}
