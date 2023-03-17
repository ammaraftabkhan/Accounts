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
    public class AccountHeadType_Val : AbstractValidator<VM_AccountHeadType>
    {
        public AccountHeadType_Val() 
        {

            RuleFor(x => x.AcHeadTypeName).NotEmpty();



        }
    }
    public class AccountHead_Val : AbstractValidator<VM_AccountHeads>
    {
        public AccountHead_Val()
        {
            RuleFor(x => x.AcHeadName).NotEmpty();
            RuleFor(x => x.AcHeadTypeId).NotEmpty();

        }
    }
    public class AccountControl_Val : AbstractValidator<VM_AccountControl>
    {
        public AccountControl_Val()
        {
            RuleFor(x => x.AcControlName).NotEmpty();
            RuleFor(x => x.AcHeadId).NotEmpty();

        }
    }
    public class AccountLedger_Val : AbstractValidator<VM_AccountLedger>
    {
        public AccountLedger_Val()
        {
            RuleFor(x => x.AcLedgerName).NotEmpty();
            RuleFor(x => x.AcControlId).NotEmpty();


        }
    }
}
