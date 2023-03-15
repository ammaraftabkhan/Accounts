using Accounts.Common.Virtual_Models;
using Accounts.Core.Models;
using FluentValidation;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Common.Validator
{
    public class AccountHeadType_Val : AbstractValidator<T>
    {
        public AccountHeadType_Val() 
        {

            //RuleFor(x => x.AcHeadTypeCode).EmailAddress().When(x => !string.IsNullOrEmpty(x.AcHeadTypeCode)).NotEmpty();

        }
    }
}
