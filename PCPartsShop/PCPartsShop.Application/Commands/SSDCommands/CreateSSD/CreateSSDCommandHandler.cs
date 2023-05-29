using MediatR;
using PCPartsShop.Domain.Models;
using PCPartsShop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Commands.SSDCommands.CreateSSD
{
    public class CreateSSDCommandHandler : IRequestHandler<CreateSSDCommand, SSD>
    {
        private readonly PCPartsShopContext _dbContext;
        public CreateSSDCommandHandler(PCPartsShopContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<SSD> Handle(CreateSSDCommand request, CancellationToken cancellationToken)
        {
            var ssd = new SSD
            {
                Make = request.Make,
                Model = request.Model,
                Image = request.Image,
                Price = request.Price,
                Capacity = request.Capacity,
                Connector = request.Connector,
            };

            _dbContext.SSDs.Add(ssd);
            await _dbContext.SaveChangesAsync();

            return ssd;
        }
    }
}
