﻿using Accounts.Common.Virtual_Models;
using Accounts.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Repository.Repository
{
    public interface IAccountHeadsRepository
    {
        List<AccountHead> GetAccountHead();
        AccountHead FindAccountHead(long id);
        bool UpdateAccountHead(VM_AccountHeads _VM_AccountHeads);
        bool DeleteAccountHead(int id);
        bool AddAccountHead(VM_AccountHeads _VM_AccountHeads);
    }
}
