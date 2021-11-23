using MediatR;
using PCPartsShop.Interfaces;
using PCPartsShop.Models;
using PCPartsShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.Commands.RAMCommands.CreateRAM
{
    public class CreateRAMCommandHandler : IRequestHandler<CreateRAMCommand, Guid>
    {
        private IComponentRepository<RAM> _RAMs;

        public CreateRAMCommandHandler()
        {
            
        }
        private void EstablishConnection()
        {
            string connectionString = @"Server=RADULZ-DESKTOP\SQLEXPRESS;Database=Amdaris_PCPartsShop;Trusted_Connection=True;";
            var dbContext = new PCPartsShopContext(connectionString);
            dbContext.Database.EnsureCreated();
            _RAMs = new RAMRepository(dbContext);
        }

        public Task<Guid> Handle(CreateRAMCommand request, CancellationToken cancellationToken)
        {
            EstablishConnection();
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
            _RAMs.Add(r);
            return Task.FromResult(r.ComponentId);
        }
    }
}

