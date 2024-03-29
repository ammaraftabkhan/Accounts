﻿using Accounts.Common.DataTable_Model;
using Accounts.Common.Virtual_Models;
using Accounts.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Repository.Repository
{
    public interface IAccountControlRespository
    {
        List<dynamic> GetAllAccountControl(FilterModel filter);
        AccountControl FindAccountControl(long id);
        bool UpdateAccountControl(VM_AccountControl _VM_AccountControl);
        bool DeleteAccountControl(int id);
        bool AddAccountControl(VM_AccountControl _VM_AccountControl);
    }
}

