using System;
namespace AcxiomCRM.Models {
    public class Activity {
        public int ActivityId { get; set; }
        public string? ActivityType { get; set; }
        public string? Subject { get; set; }
        public string? Description { get; set; }
        public DateTime ActivityDate { get; set; } = DateTime.Now;
        public int? CustomerId { get; set; }
        public int? LeadId { get; set; }
        public string? AssignedTo { get; set; }
        public string Status { get; set; } = "Planned";
    }
}
