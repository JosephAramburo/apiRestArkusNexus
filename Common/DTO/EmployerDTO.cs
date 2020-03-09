using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.DTO
{
    public class EmployerDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string MotherLastName { get; set; }
        public byte Status { get; set; }
        public DateTime AdmissionDate { get; set; }
        public decimal BaseIncome { get; set; }
        public decimal BreakfastDeduction { get; set; }
        public decimal SavingsDeduction { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ?UpdatedAt { get; set; }
        public int ?UpdatedBy { get; set; }
    }
}
