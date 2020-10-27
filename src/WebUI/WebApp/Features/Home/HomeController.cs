using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GM.WebApp.Features.Home
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogTrace("Hello from HomeController Index!");
            return new VirtualFileResult("~/index.html", "text/html");
             //return View();
        }

        // Todo - Learn what this code does.
        // I copied it from the HomeController.cs that was created in VS when I selected Asp.Net 3.1.
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public class ErrorViewModel
        {
            public string RequestId { get; set; }

            public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        }

    }
}
