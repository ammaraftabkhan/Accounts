﻿using Accounts.Common.DataTable_Model;
using Accounts.Common.Virtual_Models;
using Accounts.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Repository.Repository
{
    public interface ILanguageServices
    {
        List<dynamic> GetAllLanguage(FilterModel filter);
        Language FindLanguage(int id);
        bool UpdateLanguage(VM_Language _VM_Language);
        bool DeleteLanguage(int id);
        bool AddLanguage(VM_Language _VM_Language);
    }
}
