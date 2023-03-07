using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Common.Virtual_Models
{
    public class VM_Address
    {
        public long AddressId { get; set; }
        public int AddressTypeId { get; set; }
        public long? AcProfileId { get; set; }
        public long? AcContactId { get; set; }
        public int CivilEntityId { get; set; }
        [StringLength(50)]
        public string? Long { get; set; }
        [StringLength(50)]
        public string? Lat { get; set; }
        public string? Tag { get; set; }
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
    }
}
