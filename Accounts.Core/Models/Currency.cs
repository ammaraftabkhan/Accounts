using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Accounts.Core.Models
{
    public partial class Currency
    {
        public Currency()
        {
            AccountProfiles = new HashSet<AccountProfile>();
            CivilEntitiesCurrencies = new HashSet<CivilEntitiesCurrency>();
        }

        [Key]
        public int CurrencyId { get; set; }
        [StringLength(50)]
        public string CurrencyName { get; set; } = null!;
        [StringLength(50)]
        public string CurrencyCode { get; set; } = null!;
        [StringLength(10)]
        public string CurrencySign { get; set; } = null!;
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

        [InverseProperty(nameof(AccountProfile.Currency))]
        public virtual ICollection<AccountProfile> AccountProfiles { get; set; }
        [InverseProperty(nameof(CivilEntitiesCurrency.Currency))]
        public virtual ICollection<CivilEntitiesCurrency> CivilEntitiesCurrencies { get; set; }
    }
}
