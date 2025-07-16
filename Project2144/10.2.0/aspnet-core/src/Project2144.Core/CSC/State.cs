using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using Project2144.Cities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2144.CSC
{
    public class State : FullAuditedEntity<Guid>  
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Code { get; set; }    
        public bool IsActive { get; set; }=true;
        //foreign keys
        public Guid CountryId { get; set; }
        // Navigation Properties
        public virtual Country Country { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}
