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
            var res = _context.RAMs.FirstOrDefaultAsync(u => u.ComponentId == request.RAMId);
            if (res is null)
            {
                return null;
            }
            var r = new RAM
            {
                ComponentId = request.RAMId,
                Make = request.Make,
                Model = request.Model,
                Price = request.Price,
                Image = request.Image,
                Capacity = request.Capacity,
                Freq = request.Freq,
                Type = request.Type,
                Voltage = request.Voltage,
            };
            _context.RAMs.Update(r);
            await _context.SaveChangesAsync();
            return r;
        }
    }
}
