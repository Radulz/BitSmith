using MediatR;
using Microsoft.EntityFrameworkCore;
using PCPartsShop.Domain.Models;
using PCPartsShop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Commands.CoolerCommands.UpdateCooler
{
    public class UpdateCoolerCommandHandler : IRequestHandler<UpdateCoolerCommand, Cooler>
    {
        private readonly PCPartsShopContext _dbContext;
        public UpdateCoolerCommandHandler(PCPartsShopContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Cooler> Handle(UpdateCoolerCommand request, CancellationToken cancellationToken)
        {
            var cooler = await _dbContext.Coolers.FirstOrDefaultAsync(x => x.ComponentId == request.CoolerId);

            if (cooler == null)
            {
                return null;
            }

            cooler.Make = request.Make;
            cooler.Model= request.Model;
            cooler.Image= request.Image;
            cooler.Price= request.Price;
            cooler.RadiatorLength= request.RadiatorLength;
            cooler.Height= request.Height;
            cooler.CoolingType= request.CoolingType;
            cooler.NumberOfHeatPipes= request.NumberOfHeatPipes;

            _dbContext.Coolers.Update(cooler);
            await _dbContext.SaveChangesAsync();
            return cooler;
        }
    }
}
