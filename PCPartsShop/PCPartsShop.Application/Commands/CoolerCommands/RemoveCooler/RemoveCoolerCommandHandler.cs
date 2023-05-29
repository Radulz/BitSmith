using MediatR;
using Microsoft.EntityFrameworkCore;
using PCPartsShop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Commands.CoolerCommands.RemoveCooler
{
    public class RemoveCoolerCommandHandler : IRequestHandler<RemoveCoolerCommand, bool>
    {
        private readonly PCPartsShopContext _dbContext;
        public RemoveCoolerCommandHandler(PCPartsShopContext dbContext)
        {
            _dbContext= dbContext;
        }
        public async Task<bool> Handle(RemoveCoolerCommand request, CancellationToken cancellationToken)
        {
            var cooler = await _dbContext.Coolers.FirstOrDefaultAsync(x => x.ComponentId == request.CoolerId);
            if (cooler == null)
            {
                return false;
            }

            _dbContext.Coolers.Remove(cooler);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
