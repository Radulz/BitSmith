using MediatR;
using Microsoft.AspNetCore.Http;
using PCPartsShop.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Commands.FileUploadCommands
{
    public class FileUploadCommand : IRequest<BlobResponseDto>
    {
        public IFormFile ImageFile { get; set; }
    }
}
