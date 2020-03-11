using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTO
{
    public class PayrollFiltersRequest
    {
        public int Page { get; set; }
        public int Id { get; set; }
        public int EmployerId { get; set; }
        public string NameEmployer { get; set; }
        public string EmailEmployer { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public byte Status { get; set; }
        public int Limit { get; set; }
    }
}
