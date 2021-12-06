using MediatR;
using Microsoft.EntityFrameworkCore;
using PCPartsShop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Commands.MOBOCommands.RemoveMOBO
{
    public class RemoveMOBOCommandHandler : IRequestHandler<RemoveMOBOCommand, bool>
    {
        private readonly PCPartsShopContext _context;
        public RemoveMOBOCommandHandler(PCPartsShopContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(RemoveMOBOCommand request, CancellationToken cancellationToken)
        {
            var mobo = await _context.MOBOs.FirstOrDefaultAsync(m => m.ComponentId == request.MOBOId);
            if (mobo is null)
            {
                return false;
            }
            _context.MOBOs.Remove(mobo);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
