using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Common.Virtual_Models
{
    public class VM_AccountLedger
    {
        public long AcLedgerId { get; set; }
        //public string AcLedgerCode { get; set; }
        [StringLength(50)]
        public string AcLedgerName { get; set; } = null!;
        public long? AcControlId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public int Createdby { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? PostedOn { get; set; }
        public int? PostedBy { get; set; }
    }
}
