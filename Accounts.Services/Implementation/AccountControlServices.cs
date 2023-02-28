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

        public bool AddAccountControl(int id, VM_AccountControl _VM_AccountControl)
        {
            return accountControlRespository.AddAccountControl(id,_VM_AccountControl);
        }

        public bool DeleteAccountControl(int id)
        {
            return accountControlRespository.DeleteAccountControl(id);
        }

        public AccountControl FindAccountControl(long id)
        {
            return accountControlRespository.FindAccountControl(id);
        }

        public List<AccountControl> GetAllAccountControl()
        {
            return accountControlRespository.GetAllAccountControl();
        }

        public bool UpdateAccountControl(VM_AccountControl _VM_AccountControl)
        {
            return accountControlRespository.UpdateAccountControl(_VM_AccountControl);
        }
    }
}
