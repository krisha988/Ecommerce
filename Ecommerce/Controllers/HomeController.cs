using Ecommerce.DAO;
using Ecommerce.Models;
using Ecommerce.Views;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ecommerce.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context=context;
        }
        private readonly ILogger<HomeController> _logger;

       

        public IActionResult Index()
        {
            DashboardVM vm = new DashboardVM();
             vm.categoryinfo=_context.Category.ToList();
               vm.productitem=_context.ProductItem.ToList();


            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Contact()
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
