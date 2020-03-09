using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTO
{
    public class EmployerFiltersRequest
    {
        public int Page { get; set; }
        public int Id { get; set; }    
        public string Email { get; set; }    
        public string Name { get; set; }    
        public DateTime AdmissionDate { get; set; }
        public int Role { get; set; }
        public byte Status { get; set; }
        public int Limit { get; set; }
    }
}
