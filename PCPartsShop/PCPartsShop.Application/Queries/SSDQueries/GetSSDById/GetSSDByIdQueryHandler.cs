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

namespace PCPartsShop.Application.Queries.SSDQueries.GetSSDById
{
    public class GetSSDByIdQueryHandler : IRequestHandler<GetSSDByIdQuery, SSD>
    {
        private readonly PCPartsShopContext _dbContext;
        public GetSSDByIdQueryHandler(PCPartsShopContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<SSD> Handle(GetSSDByIdQuery request, CancellationToken cancellationToken)
        {
            var ssd = await _dbContext.SSDs.FirstOrDefaultAsync(x => x.ComponentId == request.SSDId);

            return ssd;
        }
    }
}
