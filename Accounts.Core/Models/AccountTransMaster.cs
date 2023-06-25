using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Accounts.Core.Models
{
    [Table("AccountTransMaster")]
    public partial class AccountTransMaster
    {
        public AccountTransMaster()
        {
            AccountTransDetails = new HashSet<AccountTransDetail>();
        }

        [Key]
        public long AcTransMasterId { get; set; }
        public int AcTransTypeId { get; set; }
        public long FiscalYearId { get; set; }
        [Column(TypeName = "date")]
        public DateTime AcTransDate { get; set; }
        [StringLength(50)]
        public string? AcDocNum { get; set; }
        public string AcTransNum { get; set; }
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

        [ForeignKey(nameof(AcTransTypeId))]
        [InverseProperty(nameof(AccountTransType.AccountTransMasters))]
        public virtual AccountTransType AcTransType { get; set; } = null!;
        [InverseProperty(nameof(AccountTransDetail.AcTransMaster))]
        public virtual ICollection<AccountTransDetail> AccountTransDetails { get; set; }
    }
}