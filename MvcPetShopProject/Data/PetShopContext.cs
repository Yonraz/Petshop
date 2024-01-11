using Microsoft.EntityFrameworkCore;
using MvcPetShopProject.Models;

namespace MvcPetShopProject.Data
{
    public class PetShopContext : DbContext
    {
        public PetShopContext(DbContextOptions<PetShopContext> options) : base(options)
        {
        }

        public DbSet<Animal>? Animals { get; set; }
        public DbSet<Comment>? Comments { get; set; }
        public DbSet<Category>? Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>().HasData( 
                    new Animal() { AnimalId = 11, Name = "Itzik", Age = 2, PictureName = "itzik.jpg", 
                        Description = "Itzik is a nice dog", CategoryId = 1 },
                    new Animal() { AnimalId = 12, Name = "Nissim", Age = 5, PictureName = "nissim.jpg", 
                        Description = "Nissim is a cat", CategoryId = 1 },
                    new Animal() { AnimalId = 13, Name = "Shlomo", Age = 1, PictureName = "shlomo.jpg", CategoryId = 3},
                    new Animal() {
                        AnimalId = 14,
                        Name = "Avi", Age = 3, PictureName = "avi.jpg", 
                                           Description = "Avi is a nice bird", CategoryId = 3 },
                    new Animal() {
                        AnimalId = 15,
                        Name = "Shimon", Age = 2, PictureName = "shimon.jpg", 
                                                              Description = "Shimon is a nice snake", CategoryId = 2 },
                    new Animal() {
                        AnimalId = 16,
                        Name = "Moshe", Age = 2, PictureName = "moshe.jpg", 
                                                                                 Description = "Moshe is a nice bear", CategoryId = 1 }
                );
            modelBuilder.Entity<Comment>().HasData(
                    new Comment() { CommentId = 1, Author = "Guy", Content = "This is a comment", PublishDate = new DateTime(2022,12,20,18,20,22), AnimalId = 12 },
                    new Comment() {CommentId = 2, Author = "Dotan", Content = "This is another comment", PublishDate = new DateTime(2023, 2, 13, 13, 25, 22), AnimalId = 11 },
                    new Comment() { CommentId = 3, Author = "Amir", Content = "This is a comment", PublishDate = new DateTime(2023, 1, 2, 16, 53, 22), AnimalId = 15 },
                    new Comment() { CommentId = 4, Author = "Shlomo", Content = "This is a comment", PublishDate = new DateTime(2023, 1, 2, 16, 53, 22), AnimalId = 15 },
                    new Comment() { CommentId = 5, Author = "Avi", Content = "This is a comment", PublishDate = new DateTime(2023, 1, 2, 16, 53, 22), AnimalId = 14 },
                    new Comment() { CommentId = 6, Author = "Shimon", Content = "This is a comment", PublishDate = new DateTime(2023, 1, 2, 16, 53, 22), AnimalId = 16 },
                    new Comment() { CommentId = 7, Author = "Moshe", Content = "This is a comment", PublishDate = new DateTime(2023, 1, 2, 16, 53, 22), AnimalId = 11 }
                );
            modelBuilder.Entity<Category>().HasData(
                    new Category() { CategoryId = 1, Name = "Mammal" },
                    new Category() { CategoryId = 2, Name = "Reptile" },
                    new Category() { CategoryId = 3, Name = "Bird" },
                    new Category() { CategoryId = 4, Name = "Fish" }
                );

        }
    }
}
