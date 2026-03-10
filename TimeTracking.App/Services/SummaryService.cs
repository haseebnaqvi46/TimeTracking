using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TimeTracking.App.ViewModels;
using TimeTracking.Infrastructure.Configuration;
using TimeTracking.Infrastructure.Data;

namespace TimeTracking.App.Services
{
    public class SummaryService: ISummaryService
    {
        private readonly TimeTrackingDbContext _context;
        private readonly int _threshold;

        public SummaryService(TimeTrackingDbContext context,IOptions<OvertimeSettings> options)
        {
            _context = context;
            _threshold = options.Value.WeeklyThresholdHours;
        }

        public async Task<List<WeeklySummaryViewModel>> GetWeeklySummary(DateTime weekStart, DateTime weekEnd)
        {
            var data = await _context.TimeEntries
                .Include(x => x.Employee)
                .Where(x => x.EntryDate >= weekStart && x.EntryDate <= weekEnd)
                .GroupBy(x => x.Employee.FullName)
                .Select(g => new WeeklySummaryViewModel
                {
                    EmployeeName = g.Key,
                    TotalHours = g.Sum(x => x.Hours),
                    IsOvertime = g.Sum(x => x.Hours) > _threshold
                })
                .ToListAsync();

            return data;
        }
    }
}
