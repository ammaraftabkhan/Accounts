using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Accounts.Core.Models
{
    public partial class CivilEntitiesCurrency
    {
        [Key]
        public int CivilEntitiesCurrencyId { get; set; }
        public long CivilEntityId { get; set; }
        public int CurrencyId { get; set; }
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

        [ForeignKey(nameof(CivilEntityId))]
        [InverseProperty("CivilEntitiesCurrencies")]
        public virtual CivilEntity CivilEntity { get; set; } = null!;
        [ForeignKey(nameof(CurrencyId))]
        [InverseProperty("CivilEntitiesCurrencies")]
        public virtual Currency Currency { get; set; } = null!;
    }
}
