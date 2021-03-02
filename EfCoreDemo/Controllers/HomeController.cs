using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EfCoreDemo.Models;
using EfCoreDemo.Data;
using Microsoft.EntityFrameworkCore;

namespace EfCoreDemo.Controllers
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

        public async Task<IActionResult> Index()
        {
            var customers = _context.Customers
                                    .Where(x => x.Name.Contains("a"))
                                    .OrderBy(o => o.Name);

            var sqlScript = customers.ToQueryString();
            Console.WriteLine(sqlScript);

            var customerList = customers.ToListAsync();

            // var cinemaCustomers = _context.Customers
            //                         .Where(x => x.Groups.Any(x => x.Group.Name.Contains("cinema")));

            var cinemaCustomers = _context.Customers.
                                        Where(x => x.Groups.Any(x => x.Name.Contains("cinema")));

             var sqlScript2 = cinemaCustomers.ToQueryString();
            Console.WriteLine(sqlScript2);

            var ccList = cinemaCustomers.ToListAsync();
            
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
