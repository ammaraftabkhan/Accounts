using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Accounts.Core.Models
{
    public partial class CivilLevel
    {
        public CivilLevel()
        {
            CivilEntities = new HashSet<CivilEntity>();
        }

        [Key]
        public int CivilLevelId { get; set; }
        public string? CivilLevelName { get; set; }
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

        [InverseProperty(nameof(CivilEntity.CivilLevel))]
        public virtual ICollection<CivilEntity> CivilEntities { get; set; }
    }
}
