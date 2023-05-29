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

namespace PCPartsShop.Application.Queries.CoolerQueries.GetCoolerById
{
    public class GetCoolerByIdQueryHandler : IRequestHandler<GetCoolerByIdQuery, Cooler>
    {
        private readonly PCPartsShopContext _dbContext;
        public GetCoolerByIdQueryHandler(PCPartsShopContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Cooler> Handle(GetCoolerByIdQuery request, CancellationToken cancellationToken)
        {
            var cooler = await _dbContext.Coolers.FirstOrDefaultAsync(x => x.ComponentId == request.CoolerId);
            
            return cooler;
        }
    }
}
