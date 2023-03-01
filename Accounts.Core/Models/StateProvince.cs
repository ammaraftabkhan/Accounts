using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Accounts.Core.Models
{
    [Table("StateProvince")]
    public partial class StateProvince
    {
        [Key]
        public long StateProvinceId { get; set; }
        [StringLength(50)]
        public string StateProvinceCode { get; set; } = null!;
        [StringLength(50)]
        public string StateProvinceName { get; set; } = null!;
        public int CountryId { get; set; }
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
