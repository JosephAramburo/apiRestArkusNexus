using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Models
{
    public class EmployerModel
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string MotherLastName { get; set; }
        public int Status { get; set; }
        public DateTime AdmissionDate { get; set; }
        public decimal BaseIncome { get; set; }
        public decimal BreakfastDeduction { get; set; }
        public decimal SavingsDeduction { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UpdatedBy { get; set; }
    }
}
