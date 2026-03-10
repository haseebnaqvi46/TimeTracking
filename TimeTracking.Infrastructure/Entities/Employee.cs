using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracking.Infrastructure.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        public string EmployeeCode { get; set; }

        public string FullName { get; set; }

        public bool IsActive { get; set; }

        public ICollection<TimeEntry> TimeEntries { get; set; }
    }
}
