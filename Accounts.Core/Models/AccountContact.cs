using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Accounts.Core.Models
{
    [Table("AccountContact")]
    public partial class AccountContact
    {
        public AccountContact()
        {
            Addresses = new HashSet<Address>();
        }

        [Key]
        public long AcContactId { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; } = null!;
        [StringLength(50)]
        public string LastName { get; set; } = null!;
        public long AcProfileId { get; set; }
        [StringLength(50)]
        public string Position { get; set; } = null!;
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
        public DateTime? PostedOn { get; set; }
        public int? PostedBy { get; set; }
        public bool IsDeleted { get; set; }
        [Required]
        public bool? IsActive { get; set; }

        [ForeignKey(nameof(AcProfileId))]
        [InverseProperty(nameof(AccountProfile.AccountContacts))]
        public virtual AccountProfile AcProfile { get; set; } = null!;
        [InverseProperty(nameof(Address.AcContact))]
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
