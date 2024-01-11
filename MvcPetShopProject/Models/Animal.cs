using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MvcPetShopProject.Models
{
    public class Animal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnimalId { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? PictureName { get; set; }
        public string? Description { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }
    }
}
