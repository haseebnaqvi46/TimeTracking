using Microsoft.AspNetCore.Mvc;
using TimeTracking.Api.DTOs;
using TimeTracking.Api.Services;

namespace TimeTracking.Api.Controllers
{
    [ApiController]
    [Route("api/time-entries")]
    public class TimeEntriesController : ControllerBase
    {
        private readonly ITimeEntryService _service;

        public TimeEntriesController(ITimeEntryService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTimeEntryDto dto)
        {
            var id = await _service.CreateAsync(dto);

            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateTimeEntryDto dto)
        {
            await _service.UpdateAsync(id, dto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);

            return NoContent();
        }
    }
}
