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
    public class AddressServices : IAddressServices

    {
        private readonly IAddressRepository _addressRepository;
        public AddressServices(IAddressRepository addressRepository) 
        {
            _addressRepository = addressRepository;
        }
        public bool AddAddress(VM_Address _VM_Address)
        {
            return _addressRepository.AddAddress(_VM_Address);
        }

        public bool DeleteAddress(int id)
        {
            return _addressRepository.DeleteAddress(id);
        }

        public Address FindAddress(int id)
        {
            return _addressRepository.FindAddress(id);
        }

        public List<Address> GetAllAddress()
        {
            return _addressRepository.GetAllAddress();
        }

        public bool UpdateAddress(VM_Address _VM_Address)
        {
            return _addressRepository.UpdateAddress(_VM_Address);
        }
    }
}
