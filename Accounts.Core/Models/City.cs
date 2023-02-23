using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Accounts.Core.Models
{
    [Table("City")]
    public partial class City
    {
        public City()
        {
            Areas = new HashSet<Area>();
        }

        [Key]
        public long CityId { get; set; }
        [StringLength(50)]
        public string CityName { get; set; } = null!;
        [StringLength(50)]
        public string CityCode { get; set; } = null!;
        [StringLength(50)]
        public string PostalCodeSuffix { get; set; } = null!;
        [StringLength(50)]
        public string? PostalCode { get; set; }
        public long StateProvinceId { get; set; }
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

        [ForeignKey(nameof(StateProvinceId))]
        [InverseProperty("Cities")]
        public virtual StateProvince StateProvince { get; set; } = null!;
        [InverseProperty(nameof(Area.City))]
        public virtual ICollection<Area> Areas { get; set; }
    }
}
