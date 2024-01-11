using Microsoft.AspNetCore.Mvc;
using MvcPetShopProject.Models;
using MvcPetShopProject.Repositories;

namespace MvcPetShopProject.Controllers
{
    public class AdminController : Controller
    {
        readonly IAnimalRepository _repository;
        public AdminController(IAnimalRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            ViewBag.Categories = _repository.Categories.ToList();
            ViewBag.Animals = _repository.Animals.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult OnCategoryChange(string selectedCategory)
        {
            selectedCategory ??= "All";
            ViewBag.Categories = _repository.Categories.ToList();
            ViewBag.SelectedCategory = selectedCategory;
            var animals = selectedCategory == "All"
                ? _repository.Animals.ToList()
                : _repository.GetAnimalsByCategory(selectedCategory);
            return PartialView("_AnimalTablePartial", animals);
        }
        [HttpPost]
        public IActionResult OnAnimalDelete(int id)
        {
            _repository.DeleteAnimal(id);
            var animals = _repository.Animals.ToList();
            return PartialView("_AnimalTablePartial", animals);
        }
        [HttpGet]
        public IActionResult EditAnimal(int id)
        {
            ViewBag.Categories = _repository.Categories.ToList();
            Animal animal = _repository.GetAnimalById(id);
            return View(animal);
        }
        [HttpPost]
        public IActionResult OnAnimalEdit(Animal animal)
        {
            try
            {
                _repository.UpdateAnimal(animal);
                string url = Url.Action("Index", "Admin")!;
                return Json(new { success = true, url });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
        public IActionResult AddAnimal()
        {
            ViewBag.Categories = _repository.Categories.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult OnAnimalAdd(Animal animal)
        {
            try
            {
                _repository.AddAnimal(animal);
                string url = Url.Action("Index", "Admin")!;
                return Json(new { success = true, url });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}
