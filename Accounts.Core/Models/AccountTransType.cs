using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Accounts.Core.Models
{
    [Table("AccountTransType")]
    public partial class AccountTransType
    {
        public AccountTransType()
        {
            AccountTransMasters = new HashSet<AccountTransMaster>();
        }

        [Key]
        public int AcTransTypeId { get; set; }
        [StringLength(50)]
        public string? AcTransTypeName { get; set; }
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

        [InverseProperty(nameof(AccountTransMaster.AcTransType))]
        public virtual ICollection<AccountTransMaster> AccountTransMasters { get; set; }
    }
}
