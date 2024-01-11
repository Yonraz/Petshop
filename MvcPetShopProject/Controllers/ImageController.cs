using Microsoft.AspNetCore.Mvc;
using MvcPetShopProject.Models.HttpModels;

namespace MvcPetShopProject.Controllers
{
    public class ImageController : Controller
    {
        [HttpPost]
        [Route("Image/UploadImage")]
        public Response UploadImage([FromForm] FileModel fileData)
        {
            Response response = new();
            try
            {
                if (fileData.FileName == null || fileData.File == null)
                {
                    throw new Exception("File not found");
                }
                var imagesDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images");
                var filePath = Path.Combine(imagesDirectory, fileData.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    fileData.File.CopyTo(stream);
                }
                response.StatusCode = 200;
                response.Message = "File uploaded successfully";
            }
            catch (Exception e)
            {
                response.StatusCode = 100;
                response.Message = e.Message;
            }
            return response;
        }
    }
}
