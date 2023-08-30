using Microsoft.AspNetCore.Http;
using SalaryManagement.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalaryManagement.Services.AzureBlobStorageService
{
    public interface IAzureBlobStorageService
    {
        Task<BlobResponseDto> UploadAsync(IFormFile file);
        Task<AzureBlobStorageModel> DownloadAsync(string blobFilename);
        Task<BlobResponseDto> DeleteAsync(string blobFilename);
        Task<List<AzureBlobStorageModel>> ListAsync();
    }
}
