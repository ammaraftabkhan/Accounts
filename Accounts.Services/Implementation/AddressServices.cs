﻿using Accounts.Common.DataTable_Model;
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

        public bool DeleteAddress(long id)
        {
            return _addressRepository.DeleteAddress(id);
        }

        public Address FindAddress(long id)
        {
            return _addressRepository.FindAddress(id);
        }

        public List<dynamic> GetAllAddress(FilterModel filter)
        {
            return _addressRepository.GetAllAddress(filter);
        }

        public bool UpdateAddress(VM_Address _VM_Address)
        {
            return _addressRepository.UpdateAddress(_VM_Address);
        }
    }
}
