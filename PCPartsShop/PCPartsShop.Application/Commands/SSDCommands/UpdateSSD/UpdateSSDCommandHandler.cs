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

namespace PCPartsShop.Application.Commands.SSDCommands.UpdateSSD
{
    public class UpdateSSDCommandHandler : IRequestHandler<UpdateSSDCommand, SSD>
    {
        private readonly PCPartsShopContext _dbContext;
        public UpdateSSDCommandHandler(PCPartsShopContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<SSD> Handle(UpdateSSDCommand request, CancellationToken cancellationToken)
        {
            var ssdToUpdate = await _dbContext.SSDs.FirstOrDefaultAsync(x => x.ComponentId == request.SSDId);

            if (ssdToUpdate == null)
            {
                return null;
            }

            ssdToUpdate.Make = request.Make;
            ssdToUpdate.Model= request.Model;
            ssdToUpdate.Image= request.Image;
            ssdToUpdate.Price= request.Price;
            ssdToUpdate.Capacity = request.Capacity;
            ssdToUpdate.Connector= request.Connector;

            _dbContext.SSDs.Update(ssdToUpdate);
            await _dbContext.SaveChangesAsync();
            return ssdToUpdate;
        }
    }
}
