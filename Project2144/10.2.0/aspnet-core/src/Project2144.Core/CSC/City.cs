using Abp.Domain.Entities.Auditing;
using Project2144.CSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2144.Cities
{
    public class City:FullAuditedEntity<Guid>
    {
        public string Name {  get; set; }   
        public bool IsActive {  get; set; } =true;
        public Guid CountryId { get; set; }
        public Guid StateId { get; set; }
        public virtual Country Country { get; set; }
        public virtual State State { get; set; }
    }
}
