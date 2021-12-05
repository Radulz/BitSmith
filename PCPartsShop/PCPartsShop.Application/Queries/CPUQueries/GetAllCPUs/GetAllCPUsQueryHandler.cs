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

namespace PCPartsShop.Application.Queries.CPUQueries.GetAllCPUs
{
    public class GetAllCPUsQueryHandler : IRequestHandler<GetAllCPUsQuery, IEnumerable<CPU>>
    {
        private readonly PCPartsShopContext _context;
        public GetAllCPUsQueryHandler(PCPartsShopContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CPU>> Handle(GetAllCPUsQuery request, CancellationToken cancellationToken)
        {
            var cpus = await _context.CPUs.ToListAsync();
            return cpus;
        }
    }
}
