using LearnNet6ApiUploadFileb01.Dtos;
using LearnNet6ApiUploadFileb01.Models;
using LearnNet6ApiUploadFileb01.Repositories.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnNet6ApiUploadFileb01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IFileService _fileService;
        private readonly IProductRepository _productRepository;

        public ProductController(IFileService fileService, IProductRepository productRepository)
        {
            _fileService = fileService;
            _productRepository = productRepository;
        }

        [HttpPost("addNewProduct")]
        public IActionResult Add([FromForm]Product model)
        {
            var status = new Status();
            if (!ModelState.IsValid)
            {
                status.StatusCode = 0;
                status.Message = "Please pass the valid data";
                return BadRequest(status);
            }
            if (model.ImageFile != null)
            {
                var fileResult = _fileService.SaveImage(model.ImageFile);
                if (fileResult.Item1 != null)
                {
                    model.ProductImage = fileResult.Item2; // getting name of image

                }

                var productRes = _productRepository.Add(model);
                if (productRes)
                {
                    status.StatusCode = 1;
                    status.Message = "Add successfully";
                }else
                {
                    status.StatusCode = 0;
                    status.Message = "Error Adding Product";
                }
            }
            return Ok(status);

        }
    }
}
