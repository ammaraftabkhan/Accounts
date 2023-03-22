using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Common.Virtual_Models
{
    public class VM_CivilEntitiesCurrency
    {
        public int CivilEntitiesCurrencyId { get; set; }
        public int CivilEntityId { get; set; }
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
        public int? TotalRows { get; set; }
    }
}
