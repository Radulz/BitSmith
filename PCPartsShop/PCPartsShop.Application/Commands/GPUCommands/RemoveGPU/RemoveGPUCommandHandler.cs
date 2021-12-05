using MediatR;
using Microsoft.EntityFrameworkCore;
using PCPartsShop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Commands.GPUCommands.RemoveGPU
{
    public class RemoveGPUCommandHandler : IRequestHandler<RemoveGPUCommand, bool>
    {
        private readonly PCPartsShopContext _context;
        public RemoveGPUCommandHandler(PCPartsShopContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(RemoveGPUCommand request, CancellationToken cancellationToken)
        {
            var gpu = await _context.GPUs.FirstOrDefaultAsync(g => g.ComponentId == request.GPUId);
            if(gpu is null)
            {
                return false;
            }
            _context.GPUs.Remove(gpu);
            await _context.SaveChangesAsync();
            return true;

        }
    }
}
