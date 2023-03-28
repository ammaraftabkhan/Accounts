using Accounts.Common.DataTable_Model;
using Accounts.Common.Virtual_Models;
using Accounts.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Services.Services
{
    public interface IAddressTypeServices
    {
        List<dynamic> GetAllAddressType(FilterModel filter);
        AddressType FindAddressType(int id);
        bool UpdateAddressType(VM_AddressType _VM_AddressType);
        bool DeleteAddressType(int id);
        bool AddAddressType(VM_AddressType _VM_AddressType);
    }
}
