using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TransportMVC.Models;
using TransportMVC.Data;

namespace TransportMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // Action for the Home/Index view
        public async Task<IActionResult> Index()
        {
            // Retrieve a list of destinations to display on the home page
            var destinations = await _context.Destinations.ToListAsync();
            return View(destinations);
        }

        // Action for the Home/Privacy view
        public IActionResult Privacy()
        {
            return View();
        }

        // Action for displaying the details of a destination
        public async Task<IActionResult> DestinationDetails(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destination = await _context.Destinations
                .FirstOrDefaultAsync(m => m.Id == id);

            if (destination == null)
            {
                return NotFound();
            }

            return View(destination);
        }

        // Action for the Error view
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}