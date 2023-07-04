using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Common.DataTable_Model
{
    public class FilterModel
    {
        public int? PageSize { get; set; } 
        public int? PageNumber { get; set; }
        [StringLength(50)]
        public string? SortColumn { get; set; } = null;
        [StringLength(4)]
        public string? SortOrder { get; set; } = null;
        [StringLength(50)]
        public string? SearchTerm { get; set; } = null;
    }
}
