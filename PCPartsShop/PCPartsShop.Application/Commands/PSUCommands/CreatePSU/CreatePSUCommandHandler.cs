using MediatR;
using PCPartsShop.Infrastructure;
using PCPartsShop_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Commands.PSUCommands.CreatePSU
{
    public class CreatePSUCommandHandler : IRequestHandler<CreatePSUCommand, PSU>
    {
        private readonly PCPartsShopContext _context;
        public CreatePSUCommandHandler(PCPartsShopContext context)
        {
            _context = context;
        }
        public async Task<PSU> Handle(CreatePSUCommand request, CancellationToken cancellationToken)
        {
            var psu = new PSU
            {
                Make = request.Make,
                Model = request.Model,
                Price = request.Price,
                Image = request.Image,
                Power = request.Power,
                Type = request.Type,
            };
            _context.PSUs.Add(psu);
            await _context.SaveChangesAsync();
            return psu;
        }
    }
}
