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
            RuleFor(x => x.Line1).NotEmpty();
            //RuleFor(x => x.Tag).NotEmpty();
            //RuleFor(x => x.AcProfileId).NotEmpty();
            //RuleFor(x => x.AcContactId).NotEmpty();

        }
    }

    public class AccountProfile_Val : AbstractValidator<VM_AccountProfile>
    {
        public AccountProfile_Val()
        {
            RuleFor(x => x.AcLedgerId).NotEmpty();
            RuleFor(x => x.CurrencyId).NotEmpty();
            RuleFor(x => x.Tel1).Matches(@"^(\+[0-9]{1,3})?" + "-" + "[0-9]{9,10}$").WithMessage("Invalid Telephone Number. Kindly enter a 9-10 digit Telephone Number along with a proper country code in country code block.");
            RuleFor(x => x.Tel2).Matches(@"^(\+[0-9]{1,3})?" + "-" + "[0-9]{9,10}$").WithMessage("Invalid Telephone Number. Kindly enter a 9-10 digit Telephone Number along with a proper country code in country code block.");
            RuleFor(x => x.Cell1).Matches(@"^(\+[0-9]{1,3})?" + "-" + "[0-9]{9,10}$").WithMessage("Invalid Cellphone Number. Kindly enter a 9-10 digit Cellphone Number along with a proper country code in country code block.");
            RuleFor(x => x.Cell2).Matches(@"^(\+[0-9]{1,3})?" + "-" + "[0-9]{9,10}$").WithMessage("Invalid Cellphone Number. Kindly enter a 9-10 digit Cellphone Number along with a proper country code in country code block.");
            RuleFor(x => x.Email).EmailAddress();


        }
    }

    public class AccountContact_Val : AbstractValidator<VM_AccountContact>
    {
        public AccountContact_Val()
        {
            RuleFor(x => x.AcProfileId).NotEmpty();
            RuleFor(x => x.Tel1).Matches(@"^(\+[0-9]{1,3})?" + "-" + "[0-9]{9,10}$").WithMessage("Invalid Telephone Number. Kindly enter a 9-10 digit Telephone Number along with a proper country code in country code block.");
            RuleFor(x => x.Tel2).Matches(@"^(\+[0-9]{1,3})?" + "-" + "[0-9]{9,10}$").WithMessage("Invalid Telephone Number. Kindly enter a 9-10 digit Telephone Number along with a proper country code in country code block.");
            RuleFor(x => x.Cell1).Matches(@"^(\+[0-9]{1,3})?" + "-" + "[0-9]{9,10}$").WithMessage("Invalid Cellphone Number. Kindly enter a 9-10 digit Cellphone Number along with a proper country code in country code block.");
            RuleFor(x => x.Cell2).Matches(@"^(\+[0-9]{1,3})?" + "-" + "[0-9]{9,10}$").WithMessage("Invalid Cellphone Number. Kindly enter a 9-10 digit Cellphone Number along with a proper country code in country code block.");
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Position).NotEmpty();
            

        }
    }
}
