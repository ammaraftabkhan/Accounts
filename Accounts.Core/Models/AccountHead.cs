using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Accounts.Core.Models
{
    public partial class AccountHead
    {
        public AccountHead()
        {
            AccountControls = new HashSet<AccountControl>();
        }

        [Key]
        public long AcHeadId { get; set; }
        public string AcHeadCode { get; set; }
        [StringLength(50)]
        public string AcHeadName { get; set; } = null!;
        public int AcHeadTypeId { get; set; }
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

        [ForeignKey(nameof(AcHeadTypeId))]
        [InverseProperty(nameof(AccountHeadType.AccountHeads))]
        public virtual AccountHeadType AcHeadType { get; set; } = null!;
        [InverseProperty(nameof(AccountControl.AcHead))]
        public virtual ICollection<AccountControl> AccountControls { get; set; }
    }
}
