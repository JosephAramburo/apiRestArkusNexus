using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTO
{
    public class PayrollFiltersResult
    {
        public int Count { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int EmployerId { get; set; }
        public Int16 ReceiptPeriod { get; set; }
        public Int16 Year { get; set; }
        public decimal BaseIncome { get; set; }
        public decimal TotalPerception { get; set; }
        public decimal SavingMoney { get; set; }
        public decimal BreakfastDeduction { get; set; }
        public decimal GasolineCard { get; set; }
        public decimal TotalDeduction { get; set; }
        public decimal Deposit { get; set; }
        public byte StatusEmployer { get; set; }
    }
}
