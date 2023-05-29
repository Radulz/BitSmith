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

namespace PCPartsShop.Application.Queries.CoolerQueries.GetAllCoolers
{
    public class GetAllCoolersQueryHandler : IRequestHandler<GetAllCoolersQuery, IEnumerable<Cooler>>
    {
        private readonly PCPartsShopContext _dbContext;
        public GetAllCoolersQueryHandler(PCPartsShopContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Cooler>> Handle(GetAllCoolersQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Coolers.ToListAsync();
        }
    }
}
