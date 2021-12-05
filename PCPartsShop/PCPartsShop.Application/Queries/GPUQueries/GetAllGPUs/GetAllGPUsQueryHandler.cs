using MediatR;
using Microsoft.EntityFrameworkCore;
using PCPartsShop.Infrastructure;
using PCPartsShop_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Queries.GPUQueries.GetAllGPUs
{
    public class GetAllGPUsQueryHandler : IRequestHandler<GetAllGPUsQuery, IEnumerable<GPU>>
    {
        private readonly PCPartsShopContext _context;
        public GetAllGPUsQueryHandler(PCPartsShopContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<GPU>> Handle(GetAllGPUsQuery request, CancellationToken cancellationToken)
        {
            var gpus = await _context.GPUs.ToListAsync();
            return gpus;
        }
    }
}
