using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2144.Citites.Dto
{
    public class CreateCityDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public bool IsActive { get; set; } = true;

        [Required]
        public Guid CountryId { get; set; }

        [Required]
        public Guid StateId { get; set; }
    }
}
