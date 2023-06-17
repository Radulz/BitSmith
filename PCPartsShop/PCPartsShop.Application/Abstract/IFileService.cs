using Microsoft.AspNetCore.Http;
using PCPartsShop.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Abstract
{
    public interface IFileService
    {
        public Task<BlobResponseDto> UploadAsync(IFormFile blob);
        public Task<BlobDto> GetBlobByNameAsync(string blobName);
    }
}
