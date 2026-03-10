using TimeTracking.Api.DTOs;

namespace TimeTracking.Api.Services
{
    public interface ITimeEntryService
    {
        Task<int> CreateAsync(CreateTimeEntryDto dto);

        Task UpdateAsync(int id, UpdateTimeEntryDto dto);

        Task DeleteAsync(int id);
    }
}
