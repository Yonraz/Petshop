using MvcPetShopProject.Models;

namespace MvcPetShopProject.Repositories
{
    public interface IAnimalRepository
    {
        IEnumerable<Animal> Animals { get; }
        IEnumerable<Category> Categories { get; }
        IEnumerable<Comment> Comments { get; }
        IEnumerable<Animal> GetAnimalsByCategory(string category);
        IEnumerable<Animal> GetMostCommentedAnimals(int amount);
        Animal GetAnimalById(int id);
        bool AnimalExists(int id);
        void AddAnimal(Animal animal);
        void AddCategory(Category category);
        void AddComment(Comment comment);
        void DeleteAnimal(int id);
        void DeleteCategory(int id);
        void DeleteComment(int id);
        void UpdateAnimal(Animal animal);
        void UpdateCategory(int id);
        void UpdateComment(int id);
        IEnumerable<Comment> GetCommentsDescending(int id);
    }
}
