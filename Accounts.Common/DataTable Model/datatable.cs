using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Common.DataTable_Model
{
    public class datatable
    {
        public int @PageSize { get; set; }
        public int @PageNumber { get; set; }
        [StringLength(50)]
        public string @SortColumn { get; set; }
        [StringLength(4)]
        public string @SortOrder { get; set; }
        [StringLength(50)]
        public string @SearchTerm { get; set; }
    }
}
