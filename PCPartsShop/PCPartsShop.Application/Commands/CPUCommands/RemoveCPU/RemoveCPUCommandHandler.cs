using MediatR;
using Microsoft.EntityFrameworkCore;
using PCPartsShop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Commands.CPUCommands.RemoveCPU
{
    public class RemoveCPUCommandHandler : IRequestHandler<RemoveCPUCommand, bool>
    {
        private readonly PCPartsShopContext _context;
        public RemoveCPUCommandHandler(PCPartsShopContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(RemoveCPUCommand request, CancellationToken cancellationToken)
        {
            var cpu = await _context.CPUs.FirstOrDefaultAsync(c => c.ComponentId == request.CPUId);
            bool res = true;
            if(cpu is null)
            {
                res = false;
                return res;
            }
            _context.CPUs.Remove(cpu);
            await _context.SaveChangesAsync();
            return res;
        }
    }
}
