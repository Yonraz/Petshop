
using Microsoft.AspNetCore.Mvc;
using MvcPetShopProject.Data;
using MvcPetShopProject.Models;
using MvcPetShopProject.Repositories;

namespace MvcPetShopProject.Controllers
{
    public class PetShopController : Controller
    {
        private readonly IAnimalRepository _repository;
        public PetShopController(IAnimalRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Home()
        {
            IEnumerable<Animal> animals = _repository.GetMostCommentedAnimals(2);
            return View(animals);
        }
        public IActionResult Catalog()
        {
            IEnumerable<Animal> animals = _repository.Animals.ToList();
            IEnumerable<Category> categories = _repository.Categories.ToList();
            ViewBag.Animals = animals;
            ViewBag.Categories = categories;
            return View();
        }
        [HttpPost]
        public IActionResult CatalogSelection(string selectedCategory)
        {
            ViewBag.Categories = _repository.Categories.ToList();
            ViewBag.SelectedCategory = selectedCategory;
            var animals = selectedCategory == "All" 
                ? _repository.Animals.ToList()
                : _repository.GetAnimalsByCategory(selectedCategory);
            return PartialView("_AnimalCardGridPartial", animals);
        }
    }
}
