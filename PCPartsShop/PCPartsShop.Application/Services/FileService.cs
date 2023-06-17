using Azure.Storage;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using PCPartsShop.Application.Abstract;
using PCPartsShop.Domain.ConfigurationDtos;
using PCPartsShop.Domain.Dtos;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Services
{
    public class FileService : IFileService
    {
        private readonly IOptions<AzureBlobStorageConfig> _options;
        private readonly BlobContainerClient _filesContainer;


        public FileService(IOptions<AzureBlobStorageConfig> options)
        {
            _options = options;
            var credential = new StorageSharedKeyCredential(options.Value.StorageAccountName, options.Value.StorageAccountKey);
            var blobUri = $"https://{options.Value.StorageAccountName}.blob.core.windows.net";
            var blobServiceClient = new BlobServiceClient(new Uri(blobUri), credential);
            _filesContainer = blobServiceClient.GetBlobContainerClient("product-images");
        }

        public async Task<BlobResponseDto> UploadAsync(IFormFile blob)
        {
            BlobResponseDto response = new();
            BlobClient client = _filesContainer.GetBlobClient(blob.FileName);

            await using (Stream? data = blob.OpenReadStream())
            {
                await client.UploadAsync(data);
            }

            response.Status = $"File {blob.FileName} Uploaded successfully";
            response.Error = false;
            response.Blob.Uri = client.Uri.AbsoluteUri;
            response.Blob.Name = client.Name;

            return response;
        }

        public async Task<BlobDto> GetBlobByNameAsync(string blobName)
        {
            await foreach (var file in _filesContainer.GetBlobsAsync())
            {
                string uri = _filesContainer.Uri.ToString();
                var name = file.Name;
                var fullUri = $"{uri}/{name}";

                if (name == blobName) 
                {
                    var blob = new BlobDto
                    {
                        Uri = fullUri,
                        Name = name,
                        ContentType = file.Properties.ContentType,
                    };
                    return blob;
                }
            }
            return null;
        }
    }
}
