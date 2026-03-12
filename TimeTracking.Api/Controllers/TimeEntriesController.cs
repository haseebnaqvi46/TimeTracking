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
            try
            {
                var id = await _service.CreateAsync(dto);

                return Ok(id);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new
                {
                    message = "Failed to create time entry"
                });
            }
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] TimeEntryQueryDto query)
        {
            var result = await _service.GetAsync(query);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateTimeEntryDto dto)
        {
            try
            {
                await _service.UpdateAsync(id, dto);

                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new
                {
                    message = ex.Message
                });
            }
            catch (Exception)
            {
                return StatusCode(500, new
                {
                    message = "Failed to update time entry"
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);

            return NoContent();
        }
    }
}
