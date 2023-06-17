using MediatR;
using PCPartsShop.Application.Abstract;
using PCPartsShop.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Commands.FileUploadCommands
{
    public class FileUploadCommandHandler : IRequestHandler<FileUploadCommand, BlobResponseDto>
    {
        private readonly IFileService _fileService;

        public FileUploadCommandHandler(IFileService fileService)
        {
            _fileService = fileService;
        }

        public async Task<BlobResponseDto> Handle(FileUploadCommand request, CancellationToken cancellationToken)
        {
            var uploadedBlob = await _fileService.GetBlobByNameAsync(request.ImageFile.FileName);

            if (uploadedBlob != null) 
            {
                var blob = new BlobResponseDto
                {
                    Blob = uploadedBlob,
                    Status = "File already present in blob container",
                    Error = false
                };
                return blob;
            }

            var res = await _fileService.UploadAsync(request.ImageFile);

            return res;
        }
    }
}
