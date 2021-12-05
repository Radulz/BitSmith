using MediatR;
using PCPartsShop.Infrastructure;
using PCPartsShop_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Commands.RAMCommands.CreateRAM
{
    public class CreateRAMCommandHandler : IRequestHandler<CreateRAMCommand, RAM>
    {
        private readonly PCPartsShopContext _context;
        public CreateRAMCommandHandler(PCPartsShopContext context)
        {
            _context = context;
        }
        public async Task<RAM> Handle(CreateRAMCommand request, CancellationToken cancellationToken)
        {
            var r = new RAM
            {
                Make = request.Make,
                Model = request.Model,
                Price = request.Price,
                Image = request.Image,
                Capacity = request.Capacity,
                Freq = request.Freq,
                Type = request.Type,
                Voltage = request.Voltage,
            };
            _context.RAMs.Add(r);
            await _context.SaveChangesAsync();
            return r;
        }
    }
}
