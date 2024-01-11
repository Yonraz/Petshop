using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcPetShopProject.Models
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentId { get; set; }
        public string? Author { get; set; }
        public string? Content { get; set; }
        public DateTime? PublishDate { get; set; }
        [ForeignKey("Animal")]
        public int AnimalId { get; set; }
        public virtual Animal? Animal { get; set; }
    }
}
