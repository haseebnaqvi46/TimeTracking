namespace TimeTracking.Api.DTOs
{
    public class TimeEntryResponseDto
    {
        public int Id { get; set; }

        public string EmployeeName { get; set; }

        public string ProjectName { get; set; }

        public DateTime EntryDate { get; set; }

        public decimal Hours { get; set; }

        public string Notes { get; set; }
    }
}
