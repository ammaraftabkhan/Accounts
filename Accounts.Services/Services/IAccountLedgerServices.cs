﻿using Accounts.Common.Virtual_Models;
using Accounts.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Services.Services
{
    public interface IAccountLedgerServices
    {
        List<AccountLedger> GetAllAccountLedger();
        AccountLedger FindAccountLedger(long id);
        bool UpdateAccountLegder(VM_AccountLedger _VM_AccountLedger);
        bool DeleteAccountLedger(int id);
        bool AddAccountLedger(int id, VM_AccountLedger _VM_AccountLedger);
    }
}
