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

namespace PCPartsShop.Application.Queries.CaseQueries.GetCaseById
{
    public class GetCaseByIdQueryHandler : IRequestHandler<GetCaseByIdQuery, Case>
    {
        private readonly PCPartsShopContext _dbContext;
        public GetCaseByIdQueryHandler(PCPartsShopContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Case> Handle(GetCaseByIdQuery request, CancellationToken cancellationToken)
        {
            var pcCase = await _dbContext.Cases.FirstOrDefaultAsync(x => x.ComponentId == request.CaseId);
            
            return pcCase;
        }
    }
}
