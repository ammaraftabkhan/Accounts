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
    public class AddressTypeServices : IAddressTypeServices
    {
        private readonly IAddressTypeRepository _addressTypeRepository;
        public AddressTypeServices(IAddressTypeRepository addressTypeRepository)
        {
            _addressTypeRepository = addressTypeRepository;
        }

        public bool AddAddressType(VM_AddressType _VM_AddressType)
        {
            return _addressTypeRepository.AddAddressType(_VM_AddressType);
        }

        public bool DeleteAddressType(int id)
        {
            return _addressTypeRepository.DeleteAddressType(id);
        }

        public AddressType FindAddressType(int id)
        {
            return _addressTypeRepository.FindAddressType(id);
        }

        public List<dynamic> GetAllAddressType(FilterModel filter)
        {
            return _addressTypeRepository.GetAllAddressType(filter);
        }

        public bool UpdateAddressType(VM_AddressType _VM_AddressType)
        {
            return _addressTypeRepository.UpdateAddressType(_VM_AddressType);
        }
    }
}
