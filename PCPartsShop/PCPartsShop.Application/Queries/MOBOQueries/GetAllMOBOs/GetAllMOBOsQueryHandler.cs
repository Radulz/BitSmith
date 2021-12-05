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

namespace PCPartsShop.Application.Queries.MOBOQueries.GetAllMOBOs
{
    public class GetAllMOBOsQueryHandler : IRequestHandler<GetAllMOBOsQuery, IEnumerable<MOBO>>
    {
        private readonly PCPartsShopContext _context;
        public GetAllMOBOsQueryHandler(PCPartsShopContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<MOBO>> Handle(GetAllMOBOsQuery request, CancellationToken cancellationToken)
        {
            var mobos = await _context.MOBOs.ToListAsync();
            return mobos;
        }
    }
}
