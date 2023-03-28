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
    public class AccountControlServices : IAccountControlServices
    {
        private readonly IAccountControlRespository accountControlRespository; 
        public AccountControlServices(IAccountControlRespository accountControlRespository)
        {
            this.accountControlRespository = accountControlRespository;
        }

        public bool AddAccountControl(VM_AccountControl _VM_AccountControl)
        {
            return accountControlRespository.AddAccountControl(_VM_AccountControl);
        }

        public bool DeleteAccountControl(int id)
        {
            return accountControlRespository.DeleteAccountControl(id);
        }

        public AccountControl FindAccountControl(long id)
        {
            return accountControlRespository.FindAccountControl(id);
        }

        public List<dynamic> GetAllAccountControl(FilterModel filter)
        {
            return accountControlRespository.GetAllAccountControl(filter);
        }

        public bool UpdateAccountControl(VM_AccountControl _VM_AccountControl)
        {
            return accountControlRespository.UpdateAccountControl(_VM_AccountControl);
        }
    }
}
