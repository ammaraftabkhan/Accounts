using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accounts.Core.Models
{
    [Table("VM_AccountHeadType")]
    public partial class VM_AccountHeadType
    {

        public int AcHeadTypeId { get; set; }
        [StringLength(50)]
        public string AcHeadTypeCode { get; set; } = null!;
        [StringLength(50)]
        public string AcHeadTypeName { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? PostedOn { get; set; }
        public int? PostedBy { get; set; }
    }
}
