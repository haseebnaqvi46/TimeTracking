namespace TimeTracking.Api.DTOs
{
    public class UpdateTimeEntryDto
    {
        public int EmployeeId { get; set; }

        public int ProjectId { get; set; }

        public DateTime EntryDate { get; set; }

        public decimal Hours { get; set; }

        public string Notes { get; set; }
    }
}
