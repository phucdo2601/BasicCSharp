using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalaryManagement.Authorize;
using SalaryManagement.Common;
using SalaryManagement.Responses;
using SalaryManagement.Services.AzureBlobStorageService;
using SalaryManagement.Utility.Validation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalaryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [ValidateModel]
    public class StorageController : ControllerBase
    {
        private readonly IAzureBlobStorageService _storage;

        public StorageController(IAzureBlobStorageService storage)
        {
            _storage = storage;
        }

        /// <summary>
        /// (Chỉ để test) Lấy tất cả các file trên Azure Storage
        /// </summary>
        [HttpGet(nameof(Get))]
        [AuthorizeRoles(UserInfo.ROLE_AD)]
        public async Task<IActionResult> Get()
        {
            List<AzureBlobStorageModel> files = await _storage.ListAsync();

            return StatusCode(StatusCodes.Status200OK, files);
        }

        /// <summary>
        /// (Chỉ để test) Upload file lên Azure Storage
        /// </summary>
        [HttpPost(nameof(Upload))]
        [AuthorizeRoles(UserInfo.ROLE_AD)]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            BlobResponseDto response = await _storage.UploadAsync(file);

            if (response.Error == true)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response.Status);
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK, response);
            }
        }

        /// <summary>
        /// (Chỉ để test) Download file trên Azure Storage dựa theo Tên file
        /// </summary>
        [HttpGet("{filename}")]
        [AuthorizeRoles(UserInfo.ROLE_AD)]
        public async Task<IActionResult> Download(string filename)
        {
            AzureBlobStorageModel file = await _storage.DownloadAsync(filename);

            if (file == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"File {filename} could not be downloaded.");
            }
            else
            {
                return File(file.Content, file.ContentType, file.Name);
            }
        }

        /// <summary>
        /// (Chỉ để test) Delete file trên Azure Storage dựa theo Tên file
        /// </summary>
        [HttpDelete("filename")]
        [AuthorizeRoles(UserInfo.ROLE_AD)]
        public async Task<IActionResult> Delete(string filename)
        {
            BlobResponseDto response = await _storage.DeleteAsync(filename);

            if (response.Error == true)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response.Status);
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK, response.Status);
            }
        }
    }
}