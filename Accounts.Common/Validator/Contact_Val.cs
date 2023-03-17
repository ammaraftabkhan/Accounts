using Accounts.Common.Virtual_Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Common.Validator
{
    public class AddressType_Val : AbstractValidator<VM_AddressType>
    {
        public AddressType_Val()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }

    public class Address_Val : AbstractValidator<VM_Address>
    {
        public Address_Val()
        {
            RuleFor(x => x.AddressTypeId).NotEmpty();
            RuleFor(x => x.CivilEntityId).NotEmpty();
        }
    }

    public class Profile_Val : AbstractValidator<VM_AccountProfile>
    {
        public Profile_Val()
        {
            RuleFor(x => x.AcLedgerId).NotEmpty();
            RuleFor(x => x.CurrencyId).NotEmpty();
            RuleFor(x => x.Tel1).Matches(@"^(\+[0-9]{1,3})?[0-9]{9,10}$").WithMessage("Invalid mobile number. Please enter a 10-digit number with an optional country code prefix.");
        }
    }
}
