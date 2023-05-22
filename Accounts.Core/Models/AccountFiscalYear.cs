using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Accounts.Core.Models
{
    [Table("AccountFiscalYear")]
    public partial class AccountFiscalYear
    {
        [Key]
        public long FiscalYearId { get; set; }
        [StringLength(50)]
        public string FiscalYearCode { get; set; } = null!;
        [StringLength(50)]
        public string FiscalYearName { get; set; } = null!;
        [Column(TypeName = "date")]
        public DateTime FiscalYearStart { get; set; }
        [Column(TypeName = "date")]
        public DateTime FiscalYearEnd { get; set; }
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
    }
}
