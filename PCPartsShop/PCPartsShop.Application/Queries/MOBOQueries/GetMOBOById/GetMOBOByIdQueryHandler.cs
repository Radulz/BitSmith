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

namespace PCPartsShop.Application.Queries.MOBOQueries.GetMOBOById
{
    public class GetMOBOByIdQueryHandler : IRequestHandler<GetMOBOByIdQuery, MOBO>
    {
        private readonly PCPartsShopContext _context;
        public GetMOBOByIdQueryHandler(PCPartsShopContext context)
        {
            _context = context;
        }
        public async Task<MOBO> Handle(GetMOBOByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.MOBOs.FirstOrDefaultAsync(m => m.ComponentId == request.MOBOId);

        }
    }
}
