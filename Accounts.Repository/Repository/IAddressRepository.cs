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
    public interface IAddressRepository
    {
        List<dynamic> GetAllAddress(FilterModel filter);
        Address FindAddress(long id);
        bool UpdateAddress(VM_Address _VM_Address);
        bool DeleteAddress(long id);
        bool AddAddress(VM_Address _VM_Address);
    }
}
