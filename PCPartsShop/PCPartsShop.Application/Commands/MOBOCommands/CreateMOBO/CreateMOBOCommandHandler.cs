using MediatR;
using PCPartsShop.Infrastructure;
using PCPartsShop_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Commands.MOBOCommands.CreateMOBO
{
    public class CreateMOBOCommandHandler : IRequestHandler<CreateMOBOCommand, MOBO>
    {
        private readonly PCPartsShopContext _context;
        public CreateMOBOCommandHandler(PCPartsShopContext context)
        {
            _context = context;
        }

        public async Task<MOBO> Handle(CreateMOBOCommand request, CancellationToken cancellationToken)
        {
            var m = new MOBO
            {
                Make = request.Make,
                Model = request.Model,
                Price = request.Price,
                Image = request.Image,
                MemoryFreqInf = request.MemoryFreqInf,
                MemoryFreqSup = request.MemoryFreqSup,
                MemoryType = request.MemoryType,
                Format = request.Format,
                Chipset = request.Chipset,
                Socket = request.Socket,
            };
            _context.MOBOs.Add(m);
            await _context.SaveChangesAsync();
            return m;
        }
    }
}
