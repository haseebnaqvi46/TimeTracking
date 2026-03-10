using Microsoft.AspNetCore.Mvc;
using TimeTracking.App.Services;


namespace TimeTracking.App.Controllers
{

    public class SummaryController : Controller
    {
        private readonly ISummaryService _service;

        public SummaryController(ISummaryService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Weekly()
        {
            var start = DateTime.Today.AddDays(-7);
            var end = DateTime.Today;

            var result = await _service.GetWeeklySummary(start, end);

            return View(result);
        }
    }
}
