using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Accounts.Core.Models
{
    public partial class AccountControl
    {
        public AccountControl()
        {
            AccountLedgers = new HashSet<AccountLedger>();
        }

        [Key]
        public long AcControlId { get; set; }
        [StringLength(50)]
        public string AcControlCode { get; set; } = null!;
        [StringLength(50)]
        public string AcControlName { get; set; } = null!;
        public long AcHeadId { get; set; }
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

        public int? TotalRows { get; set; }

        [ForeignKey(nameof(AcHeadId))]
        [InverseProperty(nameof(AccountHead.AccountControls))]
        public virtual AccountHead AcHead { get; set; } = null!;
        [InverseProperty(nameof(AccountLedger.AcControl))]
        public virtual ICollection<AccountLedger> AccountLedgers { get; set; }
    }
}
