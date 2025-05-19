using Microsoft.AspNetCore.Mvc;
using Simulation.DAL.Contexts;
using Simulation.DAL.Models;

namespace Simulation.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController()
        {
            _context = new AppDbContext();
        }
        public IActionResult Index()
        {
            List<CollectionModel> collectionModels = _context.CollectionModels.ToList();
            return View();
        }
    }
}
