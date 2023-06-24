using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Accounts.Core.Models
{
    [Table("AccountVoucherMaster")]
    public partial class AccountVoucherMaster
    {
        public AccountVoucherMaster()
        {
            AccountVoucherDetails = new HashSet<AccountVoucherDetail>();
        }

        [Key]
        public long AcVoucherMasterId { get; set; }
        public int AcVoucherTypeId { get; set; }
        public long FiscalYearId { get; set; }
        [Column(TypeName = "date")]
        public DateTime AcTransDate { get; set; }
        [StringLength(50)]
        public string AcDocNum { get; set; }
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
        public bool IsDeleted { get; set; }
        [Required]
        public bool? IsActive { get; set; }

        [ForeignKey(nameof(AcVoucherTypeId))]
        [InverseProperty(nameof(AccountVoucherType.AccountVoucherMasters))]
        public virtual AccountVoucherType AcVoucherType { get; set; } = null!;
        [InverseProperty(nameof(AccountVoucherDetail.AcVoucherMaster))]
        public virtual ICollection<AccountVoucherDetail> AccountVoucherDetails { get; set; }
    }
}
