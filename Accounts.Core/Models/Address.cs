using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Accounts.Core.Models
{
    [Table("Address")]
    public partial class Address
    {
        [Key]
        public long AddressId { get; set; }
        public int AddressTypeId { get; set; }
        public long? AcProfileId { get; set; }
        public long? AcContactId { get; set; }
        [StringLength(50)]
        public string? Long { get; set; }
        [StringLength(50)]
        public string? Lat { get; set; }
        public string? Tag { get; set; }
        public int CivilEntityId { get; set; }
        [StringLength(250)]
        public string? Line5 { get; set; }
        [StringLength(250)]
        public string? Line4 { get; set; }
        [StringLength(250)]
        public string? Line3 { get; set; }
        [StringLength(250)]
        public string? Line2 { get; set; }
        [StringLength(250)]
        public string? Line1 { get; set; }
        public string? Note { get; set; }
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

        [ForeignKey(nameof(AcContactId))]
        [InverseProperty(nameof(AccountContact.Addresses))]
        public virtual AccountContact? AcContact { get; set; }
        [ForeignKey(nameof(AcProfileId))]
        [InverseProperty(nameof(AccountProfile.Addresses))]
        public virtual AccountProfile? AcProfile { get; set; }
        [ForeignKey(nameof(AddressTypeId))]
        [InverseProperty("Addresses")]
        public virtual AddressType AddressType { get; set; } = null!;
        [ForeignKey(nameof(CivilEntityId))]
        [InverseProperty("Addresses")]
        public virtual CivilEntity CivilEntity { get; set; } = null!;
    }
}
