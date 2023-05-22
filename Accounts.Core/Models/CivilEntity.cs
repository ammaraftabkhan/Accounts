using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Accounts.Core.Models
{
    public partial class CivilEntity
    {
        public CivilEntity()
        {
            Addresses = new HashSet<Address>();
            CivilEntitiesCurrencies = new HashSet<CivilEntitiesCurrency>();
            CivilEntitiesLanguages = new HashSet<CivilEntitiesLanguage>();
        }

        [Key]
        public long CivilEntityId { get; set; }
        public string CivilEntityName { get; set; }
        public int CivilLevelId { get; set; }
        public long? CivilParentId { get; set; }
        public string? FlagImage { get; set; }
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

        public int? TotalRows { get; set; }

        [ForeignKey(nameof(CivilLevelId))]
        [InverseProperty("CivilEntities")]
        public virtual CivilLevel CivilLevel { get; set; } = null!;
        [InverseProperty(nameof(Address.CivilEntity))]
        public virtual ICollection<Address> Addresses { get; set; }
        [InverseProperty(nameof(CivilEntitiesCurrency.CivilEntity))]
        public virtual ICollection<CivilEntitiesCurrency> CivilEntitiesCurrencies { get; set; }
        [InverseProperty(nameof(CivilEntitiesLanguage.CivilEntity))]
        public virtual ICollection<CivilEntitiesLanguage> CivilEntitiesLanguages { get; set; }
    }
}
