using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTO
{
    public class EmployerFiltersResponse
    {
        public int Count { get; set; }
        public int Page { get; set; }
        public List<EmployerDTO> Employers { get; set; }
    }
}
