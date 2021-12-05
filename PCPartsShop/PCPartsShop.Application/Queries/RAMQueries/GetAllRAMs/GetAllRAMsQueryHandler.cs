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

namespace PCPartsShop.Application.Queries.RAMQueries.GetAllRAMs
{
    public class GetAllRAMsQueryHandler : IRequestHandler<GetAllRAMsQuery, IEnumerable<RAM>>
    {
        private readonly PCPartsShopContext _context;
        public GetAllRAMsQueryHandler(PCPartsShopContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RAM>> Handle(GetAllRAMsQuery request, CancellationToken cancellationToken)
        {
            var rams = await _context.RAMs.ToListAsync();
            return rams;
        }
    }
}
