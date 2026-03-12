using Microsoft.EntityFrameworkCore;
using TimeTracking.Api.DTOs;
using TimeTracking.Api.Models;
using TimeTracking.Infrastructure.Data;
using TimeTracking.Infrastructure.Entities;

namespace TimeTracking.Api.Services
{
    public class TimeEntryService : ITimeEntryService
    {
        private readonly TimeTrackingDbContext _context;
        private readonly ILogger<TimeEntryService> _logger;
        public TimeEntryService(TimeTrackingDbContext context, ILogger<TimeEntryService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<int> CreateAsync(CreateTimeEntryDto dto)
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating time entry");
                throw;
            }
            
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

        public async Task<PagedResult<TimeEntry>> GetAsync(TimeEntryQueryDto query)
        {
            var data = _context.TimeEntries
                .Include(x => x.Employee)
                .Include(x => x.Project)
                .AsQueryable();

            if (query.EmployeeId.HasValue)
                data = data.Where(x => x.EmployeeId == query.EmployeeId);

            if (query.ProjectId.HasValue)
                data = data.Where(x => x.ProjectId == query.ProjectId);

            if (query.StartDate.HasValue)
                data = data.Where(x => x.EntryDate >= query.StartDate);

            if (query.EndDate.HasValue)
                data = data.Where(x => x.EntryDate <= query.EndDate);

            var totalCount = await data.CountAsync();

            var items = await data
                .Skip((query.Page - 1) * query.PageSize)
                .Take(query.PageSize)
                .ToListAsync();

            return new PagedResult<TimeEntry>
            {
                Page = query.Page,
                PageSize = query.PageSize,
                TotalCount = totalCount,
                Data = items
            };
        }
    }
}
