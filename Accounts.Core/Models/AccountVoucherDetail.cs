using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Accounts.Core.Models
{
    [Table("AccountVoucherDetail")]
    public partial class AccountVoucherDetail
    {
        [Key]
        public long AcVoucherId { get; set; }
        public long AcVoucherMasterId { get; set; }
        public long AcLedgerId { get; set; }
        public long AcSubLedgerId { get; set; }
        public string Particulars { get; set; } = null!;
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Debit { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Credit { get; set; }
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

        [ForeignKey(nameof(AcVoucherMasterId))]
        [InverseProperty(nameof(AccountVoucherMaster.AccountVoucherDetails))]
        public virtual AccountVoucherMaster AcVoucherMaster { get; set; } = null!;
    }
}
