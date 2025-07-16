using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2144.Countries.Dto
{
    public class CreateCountryDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(10)]
        public string Code { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
