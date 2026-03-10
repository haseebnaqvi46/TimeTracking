using TimeTracking.Api.DTOs;
using TimeTracking.Infrastructure.Data;
using TimeTracking.Infrastructure.Entities;

namespace TimeTracking.Api.Services
{
    public class TimeEntryService : ITimeEntryService
    {
        private readonly TimeTrackingDbContext _context;

        public TimeEntryService(TimeTrackingDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(CreateTimeEntryDto dto)
        {
            var entity = new TimeEntry
            {
                EmployeeId = dto.EmployeeId,
                ProjectId = dto.ProjectId,
                EntryDate = dto.EntryDate,
                Hours = dto.Hours,
                Notes = dto.Notes,
                Source = "API"
            };

            _context.TimeEntries.Add(entity);

            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task UpdateAsync(int id, UpdateTimeEntryDto dto)
        {
            var entry = await _context.TimeEntries.FindAsync(id);

            if (entry == null)
                throw new Exception("Entry not found");

            entry.EmployeeId = dto.EmployeeId;
            entry.ProjectId = dto.ProjectId;
            entry.EntryDate = dto.EntryDate;
            entry.Hours = dto.Hours;
            entry.Notes = dto.Notes;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entry = await _context.TimeEntries.FindAsync(id);

            if (entry == null)
                throw new Exception("Entry not found");

            _context.TimeEntries.Remove(entry);

            await _context.SaveChangesAsync();
        }
    }
}
