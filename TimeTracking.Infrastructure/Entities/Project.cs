using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracking.Infrastructure.Entities
{
    public class Project
    {
        public int Id { get; set; }

        public string ProjectCode { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }

        public ICollection<TimeEntry> TimeEntries { get; set; }
    }
}
