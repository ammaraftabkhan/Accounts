using Accounts.Common.Virtual_Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Common.Validator
{
    public class CivilEntities_Val:AbstractValidator<VM_CivilEntity>
    {
        public CivilEntities_Val()
        {
            RuleFor(x => x.CivilLevelId).NotEmpty();
            RuleFor(x => x.CivilEntityName).NotEmpty();
            RuleFor(x => x.CivilParentId).NotEmpty();
        }
    }
    public class CivilLevel_Val : AbstractValidator<VM_CivilLevel>
    {
        public CivilLevel_Val()
        {
            
            RuleFor(x => x.CivilLevelName).NotEmpty();
        }
    }
    public class Currency_Val : AbstractValidator<VM_Currency>
    {
        public Currency_Val()
        {
            RuleFor(x => x.CurrencyCode).NotEmpty();
            RuleFor(x => x.CurrencyName).NotEmpty();
            RuleFor(x => x.CurrencySign).NotEmpty();
        }
    }
    public class CivilEntitiesCurrency_Val : AbstractValidator<VM_CivilEntitiesCurrency>
    {
        public CivilEntitiesCurrency_Val()
        {
            RuleFor(x => x.CurrencyId).NotEmpty();
            RuleFor(x => x.CivilEntityId).NotEmpty();
            
        }
    }
    public class Language_Val : AbstractValidator<VM_Language>
    {
        public Language_Val()
        {
            RuleFor(x => x.LanguageName).NotEmpty();
            RuleFor(x => x.LanguageCode).NotEmpty();
            
        }
    }
    public class CivilEntitiesLanguage_Val : AbstractValidator<VM_CivilEntitiesLanguage>
    {
        public CivilEntitiesLanguage_Val()
        {
            RuleFor(x => x.CivilEntityId).NotEmpty();
            RuleFor(x => x.LanguageId).NotEmpty();
            
        }
    }
}
