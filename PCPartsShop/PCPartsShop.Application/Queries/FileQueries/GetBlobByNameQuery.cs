using MediatR;
using PCPartsShop.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Queries.FileQueries
{
    public class GetBlobByNameQuery : IRequest<BlobDto>
    {
        public string BlobName { get; set; }
    }
}
