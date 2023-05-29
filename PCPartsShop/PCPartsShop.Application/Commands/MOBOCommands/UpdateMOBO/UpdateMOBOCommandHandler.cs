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
            var m = await _context.MOBOs.FirstOrDefaultAsync(x => x.ComponentId == request.MOBOId);

            if (m == null)
            {
                return null;
            }

            m.ComponentId = request.MOBOId;
            m.Make = request.Make;
            m.Model = request.Model;
            m.Price = request.Price;
            m.Image = request.Image;
            m.MemoryFreqInf = request.MemoryFreqInf;
            m.MemoryFreqSup = request.MemoryFreqSup;
            m.MemoryType = request.MemoryType;
            m.Format = request.Format;
            m.Chipset = request.Chipset;
            m.Socket = request.Socket;
            
            _context.MOBOs.Update(m);
            await _context.SaveChangesAsync();
            return m;
        }
    }
}
