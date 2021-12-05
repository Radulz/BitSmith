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

namespace PCPartsShop.Application.Queries.PSUQueries.GetPSUById
{
    public class GetPSUByIdQueryHandler : IRequestHandler<GetPSUByIdQuery, PSU>
    {
        private readonly PCPartsShopContext _context;
        public GetPSUByIdQueryHandler(PCPartsShopContext context)
        {
            _context = context;
        }
        public async Task<PSU> Handle(GetPSUByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.PSUs.FirstOrDefaultAsync(p => p.ComponentId == request.PSUId);

        }
    }
}
