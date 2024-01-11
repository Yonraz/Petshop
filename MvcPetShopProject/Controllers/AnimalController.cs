using Microsoft.AspNetCore.Mvc;
using MvcPetShopProject.Models;
using MvcPetShopProject.Repositories;

namespace MvcPetShopProject.Controllers
{
    public class AnimalController : Controller
    {
        readonly IAnimalRepository _repository;
        public AnimalController(IAnimalRepository repository) {
            _repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAnimalDetails(int id)
        {
            Animal? animal = null;
            ViewBag.Comments = _repository.GetCommentsDescending(id);
            try
            {
                animal = _repository.GetAnimalById(id);
                if (animal == null)
                {
                    throw new Exception("Animal not found");
                }
            } catch (Exception e)
            {
                return Content(e.Message);
            }
            return View(animal);
        }
        [HttpPost]
        public IActionResult GetCommentForm(int id)
        {
            ViewBag.AnimalId = id;
            return PartialView("_AddCommentFormPartial", 
                new Comment() { AnimalId = ViewBag.AnimalId });
        }
        [HttpPost]
        public IActionResult AddComment(Comment comment)
        {
            comment.PublishDate = DateTime.Now;
            _repository.AddComment(comment);
            return RedirectToAction("GetAnimalDetails", new { id = comment.AnimalId });
        }
        [HttpGet]
        public JsonResult CheckAnimalExists(int id)
        {
            bool exists = _repository.AnimalExists(id);
            return Json(exists);
        }
    }
}
