using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Accounts.Core.Models
{
    [Table("AccountSubLedger")]
    public partial class AccountSubLedger
    {
        [Key]
        public long AcSubLedgerId { get; set; }
        [StringLength(50)]
        public string AcSubLedgerCode { get; set; } = null!;
        [StringLength(50)]
        public string AcSubLedgerName { get; set; } = null!;
        public long AcLedgerId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? PostedOn { get; set; }
        public int? PostedBy { get; set; }
        public bool IsDeleted { get; set; }
        [Required]
        public bool? IsActive { get; set; }

        [ForeignKey(nameof(AcLedgerId))]
        [InverseProperty(nameof(AccountLedger.AccountSubLedgers))]
        public virtual AccountLedger AcLedger { get; set; } = null!;
    }
}
