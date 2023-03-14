﻿using Accounts.Common.Virtual_Models;
using Accounts.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Services.Services
{
    public interface IAccountTransMasterServices
    {
        List<AccountTransMaster> GetAllAccountTransMaster();
        AccountTransMaster FindAccountTransMaster(int id);
        bool UpdateAccountTransMaster(VM_AccountTransMaster _VM_AccountTransMaster);
        bool DeleteAccountTransMaster(int id);
        bool AddAccountTransMaster(VM_AccountTransMaster _VM_AccountTransMaster);
    }
}