using MediatR;
using Microsoft.EntityFrameworkCore;
using PCPartsShop.Domain.Models;
using PCPartsShop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Queries.SSDQueries.GetAllSSDs
{
    public class GetAllSSDsQueryHandler : IRequestHandler<GetAllSSDsQuery, IEnumerable<SSD>>
    {
        private readonly PCPartsShopContext _dbContext;
        public GetAllSSDsQueryHandler(PCPartsShopContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<SSD>> Handle(GetAllSSDsQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.SSDs.ToListAsync();
        }
    }
}
