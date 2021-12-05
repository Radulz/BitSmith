using MediatR;
using Microsoft.EntityFrameworkCore;
using PCPartsShop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Commands.RAMCommands.RemoveRAM
{
    public class RemoveRAMCommandHandler : IRequestHandler<RemoveRAMCommand, bool>
    {
        private readonly PCPartsShopContext _context;
        public RemoveRAMCommandHandler(PCPartsShopContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(RemoveRAMCommand request, CancellationToken cancellationToken)
        {
            var ram = await _context.RAMs.FirstOrDefaultAsync(r => r.ComponentId == request.RAMId);
            if(ram is null)
            {
                return false;
            }
            _context.RAMs.Remove(ram);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
