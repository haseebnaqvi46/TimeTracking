using TimeTracking.App.ViewModels;

namespace TimeTracking.App.Services
{
    public interface ITimeEntryAppService
    {
        Task<List<TimeEntryViewModel>> GetEntriesAsync();
    }
}
