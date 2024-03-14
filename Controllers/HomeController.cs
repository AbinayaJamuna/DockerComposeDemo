using DockerComposeDemo.DBModels;
using DockerComposeDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DockerComposeDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly dbProductContext dbProductContext;

        public HomeController(ILogger<HomeController> logger, dbProductContext dbProductContext)
        {
            _logger = logger;
            this.dbProductContext = dbProductContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListOfProducts()
        {
            List<Product> products = dbProductContext.Products.ToList();
            return View(products);
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