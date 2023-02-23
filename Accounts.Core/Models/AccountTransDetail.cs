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
        public long PayeeAcLedgerId { get; set; }
        public long PayeeAcSubLedgerId { get; set; }
        public long PayeeAcContactId { get; set; }
        public string? PayeeRemarks { get; set; }
        [StringLength(50)]
        public string? ChqNum { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ChqDate { get; set; }
        public long ReceiverAcLedgerId { get; set; }
        public long ReceiverAcSubLedgerId { get; set; }
        public long ReceiverAcContactId { get; set; }
        public string? ReceiverRemarks { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal Amount { get; set; }
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
