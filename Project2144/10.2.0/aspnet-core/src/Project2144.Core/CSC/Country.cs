using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2144.CSC
{
    public class Country:FullAuditedEntity<Guid>
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Code { get; set; }
         public bool IsActive { get; set; }
        public virtual ICollection<State> States { get; set; }
    }
}
