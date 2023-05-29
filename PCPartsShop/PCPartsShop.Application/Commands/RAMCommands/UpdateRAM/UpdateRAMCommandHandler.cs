using MediatR;
using Microsoft.EntityFrameworkCore;
using PCPartsShop.Infrastructure;
using PCPartsShop_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Commands.RAMCommands.UpdateRAM
{
    public class UpdateRAMCommandHandler : IRequestHandler<UpdateRAMCommand, RAM>
    {
        private readonly PCPartsShopContext _context;
        public UpdateRAMCommandHandler(PCPartsShopContext context)
        {
            _context = context;
        }

        public async Task<RAM> Handle(UpdateRAMCommand request, CancellationToken cancellationToken)
        {
            var r = await _context.RAMs.FirstOrDefaultAsync(x => x.ComponentId == request.RAMId);

            if (r == null)
            {
                return null;
            }

            r.ComponentId = request.RAMId;
            r.Make = request.Make;
            r.Model = request.Model;
            r.Price = request.Price;
            r.Image = request.Image;
            r.Capacity = request.Capacity;
            r.Freq = request.Freq;
            r.Type = request.Type;
            r.Voltage = request.Voltage;
            
            _context.RAMs.Update(r);
            await _context.SaveChangesAsync();
            return r;
        }
    }
}
