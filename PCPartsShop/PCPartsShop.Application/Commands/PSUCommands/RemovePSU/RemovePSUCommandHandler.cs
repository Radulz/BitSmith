using MediatR;
using Microsoft.EntityFrameworkCore;
using PCPartsShop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Commands.PSUCommands.RemovePSU
{

    public class RemovePSUCommandHandler : IRequestHandler<RemovePSUCommand, bool>
    {
        private readonly PCPartsShopContext _context;
        public RemovePSUCommandHandler(PCPartsShopContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(RemovePSUCommand request, CancellationToken cancellationToken)
        {
            var p = await _context.PSUs.FirstOrDefaultAsync(p => p.ComponentId == request.PSUId);
            if(p is null)
            {
                return false;
            }
            _context.PSUs.Remove(p);
            await _context.SaveChangesAsync();
            return true;

        }
    }
}
