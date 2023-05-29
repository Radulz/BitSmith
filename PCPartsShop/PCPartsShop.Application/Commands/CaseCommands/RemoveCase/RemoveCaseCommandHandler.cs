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

namespace PCPartsShop.Application.Commands.CaseCommands.RemoveCase
{
    public class RemoveCaseCommandHandler : IRequestHandler<RemoveCaseCommand, bool>
    {
        private readonly PCPartsShopContext _dbContext;

        public RemoveCaseCommandHandler(PCPartsShopContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(RemoveCaseCommand request, CancellationToken cancellationToken)
        {
            var pcCase = await _dbContext.Cases.FirstOrDefaultAsync(x => x.ComponentId == request.CaseId);

            if (pcCase == null)
            {
                return false;
            }

            _dbContext.Cases.Remove(pcCase);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
