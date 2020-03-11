using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTO
{
    public class PayrollFiltersResponse
    {
        public int Count { get; set; }
        public int Page { get; set; }
        public List<PayrollDTO> Payrolls { get; set; }
    }
}
