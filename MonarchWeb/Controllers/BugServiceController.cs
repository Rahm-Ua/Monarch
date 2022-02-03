using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MonarchBLL;
using System;

namespace MonarchWeb.Controllers
{
    public class BugServiceController : Controller
    {
        private readonly ILogger<BugServiceController> _logger;
        private readonly IBugService service;

        public BugServiceController(IBugService service, ILogger<BugServiceController> logger)
        {
            this.service = service;
            this._logger = logger;
        }

        [HttpGet]
        public IActionResult Index()

        {
            var bugs = service.GetBugs();
            return View(bugs);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                if (service.DeleteBug(id) == 1)
                {
                    return Ok();
                }
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}