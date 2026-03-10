using TimeTracking.App.ViewModels;

namespace TimeTracking.App.Services
{
    public interface ISummaryService
    {
        Task<List<WeeklySummaryViewModel>> GetWeeklySummary(DateTime weekStart, DateTime weekEnd);
    }
}
