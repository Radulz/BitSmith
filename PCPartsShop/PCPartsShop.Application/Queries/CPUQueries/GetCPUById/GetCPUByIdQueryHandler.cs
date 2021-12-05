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

namespace PCPartsShop.Application.Queries.CPUQueries.GetCPUById
{
    public class GetCPUByIdQueryHandler : IRequestHandler<GetCPUByIdQuery, CPU>
    {
        private readonly PCPartsShopContext _context;
        public GetCPUByIdQueryHandler(PCPartsShopContext context)
        {
            _context = context;
        }
        public async Task<CPU> Handle(GetCPUByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.CPUs.FirstOrDefaultAsync(c => c.ComponentId == request.CPUId);
        }
    }
}
