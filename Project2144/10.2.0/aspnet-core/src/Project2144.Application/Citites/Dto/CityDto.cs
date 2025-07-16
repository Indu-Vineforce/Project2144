using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2144.Citites.Dto
{
    public class CityDto : EntityDto<Guid>
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public bool IsActive { get; set; }

        public Guid CountryId { get; set; }

        public Guid StateId { get; set; }
    }
}
