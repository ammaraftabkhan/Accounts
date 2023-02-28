using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Accounts.Core.Models
{
    [Table("AccountLedger")]
    public partial class AccountLedger
    {
        public AccountLedger()
        {
            AccountProfiles = new HashSet<AccountProfile>();
            AccountSubLedgers = new HashSet<AccountSubLedger>();
        }

        [Key]
        public long AcLedgerId { get; set; }
        public string AcLedgerCode { get; set; }
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
        public bool IsDeleted { get; set; }
        [Required]
        public bool? IsActive { get; set; }

        [ForeignKey(nameof(AcControlId))]
        [InverseProperty(nameof(AccountControl.AccountLedgers))]
        public virtual AccountControl? AcControl { get; set; }
        [InverseProperty(nameof(AccountProfile.AcLedger))]
        public virtual ICollection<AccountProfile> AccountProfiles { get; set; }
        [InverseProperty(nameof(AccountSubLedger.AcLedger))]
        public virtual ICollection<AccountSubLedger> AccountSubLedgers { get; set; }
    }
}
