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

namespace PCPartsShop.Application.Queries.RAMQueries.GetRAMById
{
    public class GetRAMByIdQueryHandler : IRequestHandler<GetRAMByIdQuery, RAM>
    {
        private readonly PCPartsShopContext _context;
        public GetRAMByIdQueryHandler(PCPartsShopContext context)
        {
            _context = context;
        }

        public async Task<RAM> Handle(GetRAMByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.RAMs.FirstOrDefaultAsync(r => r.ComponentId == request.RAMId);
        }
    }
}
