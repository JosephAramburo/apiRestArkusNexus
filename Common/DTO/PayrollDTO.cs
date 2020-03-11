using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Common.DTO
{
    public class PayrollDTO
    {
        public int Id { get; set; }
        public int EmployerId { get; set; }
        public int ReceiptPeriod { get; set; }
        public int Year { get; set; }
        public decimal BaseIncome { get; set; }        
        public decimal TotalPerception { get; set; }
        public decimal SavingMoney { get; set; }
        public decimal BreakfastDeduction { get; set; }
        public decimal GasolineCard { get; set; }
        public decimal TotalDeduction { get; set; }
        public decimal Deposit { get; set; }

        [NotMapped]
        public string Name { get; set; }
        [NotMapped]
        public string Email { get; set; }
        [NotMapped]
        public byte Status { get; set; }
    }
}
