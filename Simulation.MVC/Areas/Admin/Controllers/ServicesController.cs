using Microsoft.AspNetCore.Mvc;
using Simulation.BL.ViewModels;
using Simulation.BL.Services;
using Simulation.DAL.Models;

namespace Simulation.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServicesController : Controller
    {
        private readonly CollectionModelServices _services;
        public ServicesController()
        {
            _services = new CollectionModelServices();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CollectionModelVM collectionModelVM)
        {
            _services.Create(collectionModelVM);
            return RedirectToAction("Tables", "Dashboard");
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            _services.Delete(Id);
            return RedirectToAction("Tables", "Dashboard");
        }

        [HttpGet]
        public IActionResult Update(int Id)
        {
            CollectionModel collection = _services.GetCollectionById(Id);
            CollectionModelUpdateVM collectionModelUpdateVM = new CollectionModelUpdateVM();
            collectionModelUpdateVM.Name = collection.Name;
            collectionModelUpdateVM.Category = collection.Category;
            collectionModelUpdateVM.ItemsInCollection = collection.ItemsInCollection;
            return View(collectionModelUpdateVM);

        }
        [HttpPost]
        public IActionResult Update(int Id,CollectionModelUpdateVM collectionModelUpdateVM)
        {
            _services.Update(Id, collectionModelUpdateVM);
            return RedirectToAction("Tables", "Dashboard");
        }





    }
}
