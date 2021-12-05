using MediatR;
using PCPartsShop.Infrastructure;
using PCPartsShop_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Commands.MOBOCommands.UpdateMOBO
{
    public class UpdateMOBOCommandHandler : IRequestHandler<UpdateMOBOCommand, MOBO>
    {
        private readonly PCPartsShopContext _context;
        public UpdateMOBOCommandHandler(PCPartsShopContext context)
        {
            _context = context;
        }
        public async Task<MOBO> Handle(UpdateMOBOCommand request, CancellationToken cancellationToken)
        {
            var m = new MOBO
            {
                ComponentId = request.MOBOId,
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
            _context.MOBOs.Update(m);
            await _context.SaveChangesAsync();
            return m;
        }
    }
}
