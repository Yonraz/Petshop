using Microsoft.EntityFrameworkCore;
using MvcPetShopProject.Data;
using MvcPetShopProject.Models;

namespace MvcPetShopProject.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly PetShopContext _ctx;
        public AnimalRepository(PetShopContext context)
        {
            _ctx = context;
        }
        public IEnumerable<Animal> Animals => _ctx.Animals!;
        public IEnumerable<Category> Categories => _ctx.Categories!;
        public IEnumerable<Comment> Comments => _ctx.Comments!;
        public void AddAnimal(Animal animal)
        {
            _ctx.Animals!.Add(animal);
            _ctx.SaveChanges();
        }
        public void AddCategory(Category category)
        {
            _ctx.Categories!.Add(category);
            _ctx.SaveChanges();
        }
        public void AddComment(Comment comment)
        {
            _ctx.Comments!.Add(comment);
            _ctx.SaveChanges();
        }
        public void DeleteAnimal(int id)
        {
            Animal animal = _ctx.Animals!.First(a => a.AnimalId == id);
            _ctx.Animals!.Remove(animal);
            _ctx.SaveChanges();
        }
        public void DeleteCategory(int id)
        {
            Category category = _ctx.Categories!.First(a => a.CategoryId == id);
            _ctx.Categories!.Remove(category);
            _ctx.SaveChanges();
        }
        public void DeleteComment(int id)
        {
            Comment comment = _ctx.Comments!.First(a => a.AnimalId == id);
            _ctx.Comments!.Remove(comment);
            _ctx.SaveChanges();
        }

        public Animal GetAnimalById(int id)
        {
            return _ctx.Animals!.First(a => a.AnimalId == id);
        }
        public bool AnimalExists(int id)
        {
            return _ctx.Animals!.Any(a => a.AnimalId == id);
        }
        public void UpdateAnimal(Animal animal)
        {
            Animal original = _ctx.Animals!.First(a => a.AnimalId == animal.AnimalId);
            int newCategoryId = _ctx.Categories!.First(c => c.CategoryId == animal.CategoryId).CategoryId;
            original.Name = animal.Name ?? original.Name;
            original.Age = animal.Age > 0 ? animal.Age : original.Age;
            original.Description = animal.Description ?? original.Description;
            original.PictureName = animal.PictureName ?? original.PictureName;
            original.CategoryId = newCategoryId;
            _ctx.Animals!.Update(original);
            _ctx.ChangeTracker.DetectChanges();
            _ctx.Entry(original).State = EntityState.Modified;
            _ctx.SaveChanges();
        }
        public void UpdateCategory(int id)
        {
            Category category = _ctx.Categories!.First(a => a.CategoryId == id);
            _ctx.Categories!.Update(category);
            _ctx.SaveChanges();
        }
        public void UpdateComment(int id)
        {
            Comment comment = _ctx.Comments!.First(a => a.AnimalId == id);
            _ctx.Comments!.Update(comment);
            _ctx.SaveChanges();
        }

        public IEnumerable<Animal> GetMostCommentedAnimals(int amount = 1)
        {
            IEnumerable<Animal> animalsWithComments = Animals
                .OrderByDescending(a => a.Comments!.Count)
                .Take(amount)
                .ToList();
            return animalsWithComments;
        }

        public IEnumerable<Animal> GetAnimalsByCategory(string category)
        {
            IEnumerable<Animal> animalsByCategory = Animals
                .Where(a => a.Category!.Name!.Equals(category, StringComparison.CurrentCultureIgnoreCase))
                .ToList();
            return animalsByCategory;
        }

        public IEnumerable<Comment> GetCommentsDescending(int id)
        {
            try
            {
                var animal = Animals.FirstOrDefault(a => a.AnimalId == id); 
                return animal!.Comments!.OrderByDescending(c => c.PublishDate).ToList();
            } catch (Exception e)
            {
                return new List<Comment>();
            }
        }
    }
}
