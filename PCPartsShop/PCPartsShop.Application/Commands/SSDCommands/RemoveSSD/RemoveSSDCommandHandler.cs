using MediatR;
using Microsoft.EntityFrameworkCore;
using PCPartsShop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Commands.SSDCommands.RemoveSSD
{
    public class RemoveSSDCommandHandler : IRequestHandler<RemoveSSDCommand, bool>
    {
        private readonly PCPartsShopContext _dbContext;
        public RemoveSSDCommandHandler(PCPartsShopContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(RemoveSSDCommand request, CancellationToken cancellationToken)
        {
            var ssd = await _dbContext.SSDs.FirstOrDefaultAsync(x => x.ComponentId == request.SSDId);
            if (ssd == null)
            {
                return false;
            }

            _dbContext.SSDs.Remove(ssd);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
