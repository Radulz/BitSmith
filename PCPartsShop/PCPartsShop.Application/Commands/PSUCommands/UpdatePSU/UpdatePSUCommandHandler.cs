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
            var psu = new PSU
            {
                ComponentId = request.PSUId,
                Make = request.Make,
                Model = request.Model,
                Price = request.Price,
                Image = request.Image,
                Power = request.Power,
                Type = request.Type,
            };
            _context.PSUs.Update(psu);
            await _context.SaveChangesAsync();
            return psu;
        }
    }
}
