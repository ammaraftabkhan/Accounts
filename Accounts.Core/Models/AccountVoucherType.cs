using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Accounts.Core.Models
{
    [Table("AccountVoucherType")]
    public partial class AccountVoucherType
    {
        public AccountVoucherType()
        {
            AccountVoucherMasters = new HashSet<AccountVoucherMaster>();
        }

        [Key]
        public int AcVoucherTypeId { get; set; }
        [StringLength(50)]
        public string AcVoucherTypeName { get; set; } = null!;
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

        [InverseProperty(nameof(AccountVoucherMaster.AcVoucherType))]
        public virtual ICollection<AccountVoucherMaster> AccountVoucherMasters { get; set; }
    }
}
