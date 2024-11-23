using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MunicipalServicesManagementApp.Models;
using System.Diagnostics;

namespace MunicipalServicesManagementApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MunicipalDbContext _context;

        public HomeController(ILogger<HomeController> logger, MunicipalDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.WelcomeMessage = "Welcome to the Municipal Services Management Portal!";
            ViewBag.ServiceCount = _context.WaterSupplies.Count()
                                   + _context.WasteManagements.Count()
                                   + _context.ParkManagements.Count();
            return View();
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
