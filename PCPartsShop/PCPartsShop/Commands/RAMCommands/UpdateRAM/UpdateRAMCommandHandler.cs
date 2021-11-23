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

namespace PCPartsShop.Commands.RAMCommands.UpdateRAM
{
    public class UpdateRAMCommandHandler : IRequestHandler<UpdateRAMCommand, bool>
    {
        private  IComponentRepository<RAM> _RAMs;

        public UpdateRAMCommandHandler()
        {
            
        }
        private void EstablishConnection()
        {
            string connectionString = @"Server=RADULZ-DESKTOP\SQLEXPRESS;Database=Amdaris_PCPartsShop;Trusted_Connection=True;";
            var dbContext = new PCPartsShopContext(connectionString);
            dbContext.Database.EnsureCreated();
            _RAMs = new RAMRepository(dbContext);
        }
        public Task<bool> Handle(UpdateRAMCommand request, CancellationToken cancellationToken)
        {
            EstablishConnection();
            var r = new RAM
            {
                ComponentId = request.RAMId,
                Make = request.Make,
                Model = request.Model,
                Price = request.Price,
                Image = request.Image,
                Capacity = request.Capacity,
                Freq = request.Freq,
                Type = request.Type,
                Voltage = request.Voltage,
            };
            bool res = _RAMs.Update(r);
            return Task.FromResult(res);
        }
    }
}
