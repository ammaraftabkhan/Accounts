using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Accounts.Core.Models
{
    [Table("AccountProfile")]
    public partial class AccountProfile
    {
        public AccountProfile()
        {
            AccountContacts = new HashSet<AccountContact>();
            Addresses = new HashSet<Address>();
        }

        [Key]
        public long AcProfileId { get; set; }
        public long AcLedgerId { get; set; }
        public int CurrencyId { get; set; }
        [StringLength(50)]
        public string? BusinessName { get; set; }
        [StringLength(50)]
        public string? ChqName { get; set; }
        [StringLength(50)]
        public string? Tel1 { get; set; }
        [StringLength(50)]
        public string? Tel2 { get; set; }
        [StringLength(50)]
        public string? Cell1 { get; set; }
        [StringLength(50)]
        public string? Cell2 { get; set; }
        [StringLength(50)]
        public string? Email { get; set; }
        [Column("NTN")]
        [StringLength(50)]
        public string? Ntn { get; set; }
        [Column("STRN")]
        [StringLength(50)]
        public string? Strn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime PostedOn { get; set; }
        public int PostedBy { get; set; }
        public bool IsDeleted { get; set; }
        [Required]
        public bool? IsActive { get; set; }

        [ForeignKey(nameof(AcLedgerId))]
        [InverseProperty(nameof(AccountLedger.AccountProfiles))]
        public virtual AccountLedger AcLedger { get; set; } = null!;
        [ForeignKey(nameof(CurrencyId))]
        [InverseProperty("AccountProfiles")]
        public virtual Currency Currency { get; set; } = null!;
        [InverseProperty(nameof(AccountContact.AcProfile))]
        public virtual ICollection<AccountContact> AccountContacts { get; set; }
        [InverseProperty(nameof(Address.AcProfile))]
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
