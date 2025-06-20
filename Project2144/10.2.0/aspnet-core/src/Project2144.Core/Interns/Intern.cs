using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2144.Interns
{
    public class Intern:Entity<int>
    {
        public string Name {  get; set; }
    }
}
