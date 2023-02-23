using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Accounts.Core.Models
{
    [Table("Area")]
    public partial class Area
    {
        public Area()
        {
            Addresses = new HashSet<Address>();
        }

        [Key]
        public long AreaId { get; set; }
        [StringLength(50)]
        public string AreaCode { get; set; } = null!;
        [StringLength(50)]
        public string AreaName { get; set; } = null!;
        public long CityId { get; set; }
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

        [ForeignKey(nameof(CityId))]
        [InverseProperty("Areas")]
        public virtual City City { get; set; } = null!;
        [InverseProperty(nameof(Address.Area))]
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
