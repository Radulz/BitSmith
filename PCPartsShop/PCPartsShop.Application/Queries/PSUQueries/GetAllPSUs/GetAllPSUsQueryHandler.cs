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

namespace PCPartsShop.Application.Queries.PSUQueries.GetAllPSUs
{
    public class GetAllPSUsQueryHandler : IRequestHandler<GetAllPSUsQuery, IEnumerable<PSU>>
    {
        private readonly PCPartsShopContext _context;
        public GetAllPSUsQueryHandler(PCPartsShopContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PSU>> Handle(GetAllPSUsQuery request, CancellationToken cancellationToken)
        {
            var psus = await _context.PSUs.ToListAsync();
            return psus;
        }
    }
}
