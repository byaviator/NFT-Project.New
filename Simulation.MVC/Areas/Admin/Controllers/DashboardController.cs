using Microsoft.AspNetCore.Mvc;
using Simulation.DAL.Contexts;
using Simulation.DAL.Models;

namespace Simulation.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;
        public DashboardController()
        {
            _context = new AppDbContext();
        }
        public IActionResult Tables()
        {
            List<CollectionModel> collection = _context.CollectionModels.ToList();
            return View(collection);

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
