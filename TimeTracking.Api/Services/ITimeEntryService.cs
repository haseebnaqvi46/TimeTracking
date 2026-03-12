using TimeTracking.Api.DTOs;
using TimeTracking.Api.Models;
using TimeTracking.Infrastructure.Entities;

namespace TimeTracking.Api.Services
{
    public interface ITimeEntryService
    {
        Task<int> CreateAsync(CreateTimeEntryDto dto);

        Task UpdateAsync(int id, UpdateTimeEntryDto dto);

        Task DeleteAsync(int id);

        Task<PagedResult<TimeEntryResponseDto>> GetAsync(TimeEntryQueryDto query);
    }
}
