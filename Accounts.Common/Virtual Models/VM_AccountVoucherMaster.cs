using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Common.Virtual_Models
{
    public class VM_AccountVoucherMaster
    {
        public long AcVoucherMasterId { get; set; }
        public int AcVoucherTypeId { get; set; }
        public long FiscalYearId { get; set; }
        [Column(TypeName = "date")]
        public DateTime AcTransDate { get; set; }
        [StringLength(50)]
        public string? AcDocNum { get; set; }
        public string? Remarks { get; set; }
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
