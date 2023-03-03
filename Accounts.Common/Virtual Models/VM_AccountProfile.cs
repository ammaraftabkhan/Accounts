using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Common.Virtual_Models
{
    public class VM_AccountProfile
    {
        public long AcProfileId { get; set; }
        //public long AcLedgerId { get; set; }
        public int CurrencyId { get; set; }
        [StringLength(50)]
        public string? BusinessName { get; set; }
        [StringLength(50)]
        public string? ChqName { get; set; }
        public int? Tel1 { get; set; }
        public int? Tel2 { get; set; }
        public int? Cell1 { get; set; }
        public int? Cell2 { get; set; }
        [StringLength(50)]
        public string? Email { get; set; }
        [Column("NTN")]
        [StringLength(50)]
        public string? Ntn { get; set; }
        [Column("STRN")]
        [StringLength(50)]
        public string? Strn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime PostedOn { get; set; }
        public int PostedBy { get; set; }
    }
}
