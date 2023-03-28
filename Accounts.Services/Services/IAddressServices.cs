using Accounts.Common.DataTable_Model;
using Accounts.Common.Virtual_Models;
using Accounts.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Services.Services
{
    public interface IAddressServices
    {
        List<dynamic> GetAllAddress(FilterModel filter);
        Address FindAddress(int id);
        bool UpdateAddress(VM_Address _VM_Address);
        bool DeleteAddress(int id);
        bool AddAddress(VM_Address _VM_Address);
    }
}
