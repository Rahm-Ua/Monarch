using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MonarchBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
