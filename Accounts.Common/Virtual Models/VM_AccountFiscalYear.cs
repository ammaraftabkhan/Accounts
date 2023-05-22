using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Common.Virtual_Models
{
    public class VM_AccountFiscalYear
    {
        public long FiscalYearId { get; set; }
        [StringLength(50)]
        public string FiscalYearName { get; set; } = null!;
        [Column(TypeName = "date")]
        public DateTime FiscalYearStart { get; set; }
        [Column(TypeName = "date")]
        public DateTime FiscalYearEnd { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? PostedOn { get; set; }
        public int? PostedBy { get; set; }
    }
}
