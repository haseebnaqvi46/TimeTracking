using System.ComponentModel.DataAnnotations;

namespace TimeTracking.Api.DTOs
{
    public class UpdateTimeEntryDto
    {
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public int ProjectId { get; set; }
        public DateTime EntryDate { get; set; }
        public decimal Hours { get; set; }
        [MaxLength(500)]
        public string Notes { get; set; }
    }
}
