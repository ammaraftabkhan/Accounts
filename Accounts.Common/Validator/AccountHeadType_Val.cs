using Accounts.Core.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Common.Validator
{
    public class AccountHeadType_Val : AbstractValidator<VM_AccountHeadType>
    {
        public AccountHeadType_Val() 
        {
            RuleFor(x=>x.AcHeadTypeCode).NotEmpty();
        }
    }
}
