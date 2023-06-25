using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Accounts.Core.Models
{
    [Table("AccountTransDetail")]
    public partial class AccountTransDetail
    {
        [Key]
        public long AcTransDetailId { get; set; }
        public long AcTransMasterId { get; set; }
        public long AccountId { get; set; }
        public long AcContactId { get; set; }
        public string? Remarks { get; set; }
        public string? ChqTrType { get; set; }
        [StringLength(50)]
        public string? ChqTrIdNum { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ChqTrDate { get; set; }
        public string? ChqTrTitle { get; set; }
        public string? Bank { get; set; }
        public string? BankBranch { get; set; }
        public string? AcTitle { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal DebitAmount { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal CreditAmount { get; set; }
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

        [ForeignKey(nameof(AcTransMasterId))]
        [InverseProperty(nameof(AccountTransMaster.AccountTransDetails))]
        public virtual AccountTransMaster AcTransMaster { get; set; } = null!;
    }
}
