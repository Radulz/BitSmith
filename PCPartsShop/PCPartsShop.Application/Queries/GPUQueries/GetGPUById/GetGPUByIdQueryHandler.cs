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

namespace PCPartsShop.Application.Queries.GPUQueries.GetGPUById
{
    public class GetGPUByIdQueryHandler : IRequestHandler<GetGPUByIdQuery, GPU>
    {
        private readonly PCPartsShopContext _context;
        public GetGPUByIdQueryHandler(PCPartsShopContext context)
        {
            _context = context;
        }
        public async Task<GPU> Handle(GetGPUByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.GPUs.FirstOrDefaultAsync(g => g.ComponentId == request.GPUId);
        }
    }
}
