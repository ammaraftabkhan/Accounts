using Accounts.Common.Virtual_Models;
using Accounts.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Repository.Repository
{
    public interface IAddressTypeRepository
    {
        List<AddressType> GetAllAddressType();
        AddressType FindAddressType(int id);
        bool UpdateAddressType(VM_AddressType _VM_AddressType);
        bool DeleteAddressType(int id);
        bool AddAddressType(VM_AddressType _VM_AddressType);
    }
}
