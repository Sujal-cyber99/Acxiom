using System;
using System.ComponentModel.DataAnnotations;
namespace AcxiomCRM.Models {
    public class Customer {
        public int CustomerId { get; set; }
        public string? CustomerCode { get; set; }
        [Required] public string CustomerName { get; set; } = string.Empty;
        [Required, EmailAddress] public string Email { get; set; } = string.Empty;
        [Required, Phone] public string Phone { get; set; } = string.Empty;
        public string? CompanyName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string Status { get; set; } = "Active";
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? CreatedBy { get; set; }
    }
}
