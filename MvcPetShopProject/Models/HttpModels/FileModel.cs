namespace MvcPetShopProject.Models.HttpModels
{
    public class FileModel
    {
        public string? FileName { get; set; }
        public IFormFile? File { get; set; }
    }
}
