using Microsoft.EntityFrameworkCore;
using TimeTracking.App.ViewModels;
using TimeTracking.Infrastructure.Data;

namespace TimeTracking.App.Services
{
    public class TimeEntryAppService : ITimeEntryAppService
    {
        private readonly TimeTrackingDbContext _context;

        public TimeEntryAppService(TimeTrackingDbContext context)
        {
            _context = context;
        }

        public async Task<List<TimeEntryViewModel>> GetEntriesAsync()
        {
            return await _context.TimeEntries
                .Include(x => x.Employee)
                .Include(x => x.Project)
                .Select(x => new TimeEntryViewModel
                {
                    Id = x.Id,
                    EmployeeName = x.Employee.FullName,
                    ProjectName = x.Project.Name,
                    EntryDate = x.EntryDate,
                    Hours = x.Hours,
                    Notes = x.Notes
                })
                .ToListAsync();
        }
    }
}
