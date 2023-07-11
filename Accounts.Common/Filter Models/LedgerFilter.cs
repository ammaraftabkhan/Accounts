using Accounts.Common.DataTable_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Common.Filter_Models
{
    public class LedgerFilter/* : FilterModel*/
    {
        public int? AccountId { get; set; }
        public DateOnly? DateFrom { get; set; } = null;
        public DateOnly? DateTo { get; set; } = null;
    }
}
