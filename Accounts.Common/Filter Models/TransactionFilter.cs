using Accounts.Common.DataTable_Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Common.Filter_Models
{
    public class TransactionFilter : FilterModel
    {
        public long? MstId { get; set; }
    }
}
