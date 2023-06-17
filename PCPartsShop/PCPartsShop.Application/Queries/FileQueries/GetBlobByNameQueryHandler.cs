using MediatR;
using PCPartsShop.Application.Abstract;
using PCPartsShop.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Queries.FileQueries
{
    public class GetBlobByNameQueryHandler : IRequestHandler<GetBlobByNameQuery, BlobDto>
    {
        private readonly IFileService _fileService;
        public GetBlobByNameQueryHandler(IFileService fileService)
        {
            _fileService = fileService;
        }
        public async Task<BlobDto> Handle(GetBlobByNameQuery request, CancellationToken cancellationToken)
        {
            var result = await _fileService.GetBlobByNameAsync(request.BlobName);
            return result;
        }
    }
}
