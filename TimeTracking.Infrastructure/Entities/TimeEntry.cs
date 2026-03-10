using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracking.Infrastructure.Entities
{
    public class TimeEntry
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public int ProjectId { get; set; }

        public DateTime EntryDate { get; set; }

        public decimal Hours { get; set; }

        public string Notes { get; set; }

        public string Source { get; set; }

        public Employee Employee { get; set; }

        public Project Project { get; set; }
    }
}
