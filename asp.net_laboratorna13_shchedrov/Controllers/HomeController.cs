using asp.net_laboratorna13_shchedrov.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Diagnostics;

namespace asp.net_laboratorna13_shchedrov.Controllers
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
            Log.Debug("Debug level log: This is a debug message for troubleshooting.");
            Log.Information("Information level log: The Index action was accessed.");
            Log.Warning("Warning level log: This is a warning message, indicating a potential issue.");
            Log.Error("Error level log: This is an error message indicating an issue that occurred.");
            Log.Fatal("Fatal level log: This is a fatal message for critical failures.");

            var user = new { Name = "Bohdan", Age = 19 };
            Log.Information("User {Name} of age {Age} logged in at {Time}", user.Name, user.Age, DateTime.Now);
            Log.Information("User details: {@User}", user);

            return View();
        }

        public IActionResult Privacy()
        {
            try
            {
                throw new InvalidOperationException("Test exception for logging purposes.");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while accessing the Privacy page.");
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            Log.Warning("Warning: An error occurred and the Error page is being accessed.");
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
