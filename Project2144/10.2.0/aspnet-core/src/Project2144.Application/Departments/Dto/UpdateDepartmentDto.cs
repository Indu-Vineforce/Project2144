using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2144.Departments.Dto
{
    public class UpdateDepartmentDto:EntityDto<int>
    {
        public string Name {  get; set; }   
    }
}
