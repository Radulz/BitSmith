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

namespace PCPartsShop.Application.Commands.PSUCommands.UpdatePSU
{
    public class UpdatePSUCommandHandler : IRequestHandler<UpdatePSUCommand, PSU>
    {
        private readonly PCPartsShopContext _context;
        public UpdatePSUCommandHandler(PCPartsShopContext context)
        {
            _context = context;
        }
        public async Task<PSU> Handle(UpdatePSUCommand request, CancellationToken cancellationToken)
        {
            var psu = await _context.PSUs.FirstOrDefaultAsync(x => x.ComponentId == request.PSUId);

            if (psu == null)
            {
                return null;
            }

            psu.ComponentId = request.PSUId;
            psu.Make = request.Make;
            psu.Model = request.Model;
            psu.Price = request.Price;
            psu.Image = request.Image;
            psu.Power = request.Power;
            psu.Type = request.Type;
            
            _context.PSUs.Update(psu);
            await _context.SaveChangesAsync();
            return psu;
        }
    }
}
