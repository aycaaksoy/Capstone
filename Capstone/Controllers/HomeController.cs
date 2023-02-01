using BusinessLayer.Abstract;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAnnouncementService _announcementService;

        public HomeController(ILogger<HomeController> logger, IAnnouncementService announcementService)
        {
            _logger = logger;
            _announcementService = announcementService;
        }

        public IActionResult Index()
        {
            var values = _announcementService.TGetList();
            return View(values);
        }

        public IActionResult HeadPartial()
        {
            return PartialView();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
