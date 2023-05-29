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

namespace PCPartsShop.Application.Queries.CaseQueries.GetAllCases
{
    public class GetAllCasesQueryHandler : IRequestHandler<GetAllCasesQuery, IEnumerable<Case>>
    {
        private readonly PCPartsShopContext _dbContext;
        public GetAllCasesQueryHandler(PCPartsShopContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Case>> Handle(GetAllCasesQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Cases.ToListAsync();
        }
    }
}
