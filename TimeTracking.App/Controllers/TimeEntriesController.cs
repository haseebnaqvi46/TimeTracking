using Microsoft.AspNetCore.Mvc;
using TimeTracking.App.Services;

namespace TimeTracking.App.Controllers
{
    public class TimeEntriesController : Controller
    {
        private readonly ITimeEntryAppService _service;

        public TimeEntriesController(ITimeEntryAppService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetEntriesAsync();

            return View(data);
        }
    }
}
