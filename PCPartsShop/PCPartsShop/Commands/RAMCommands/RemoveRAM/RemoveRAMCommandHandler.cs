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

namespace PCPartsShop.Commands.RAMCommands.RemoveRAM
{
    public class RemoveRAMCommandHandler : IRequestHandler<RemoveRAMCommand, bool>
    {
        private IComponentRepository<RAM> _RAMs;

        public RemoveRAMCommandHandler()
        {
            
        }
        private void EstablishConnection()
        {
            string connectionString = @"Server=RADULZ-DESKTOP\SQLEXPRESS;Database=Amdaris_PCPartsShop;Trusted_Connection=True;";
            var dbContext = new PCPartsShopContext(connectionString);
            dbContext.Database.EnsureCreated();
            _RAMs = new RAMRepository(dbContext);
        }
        public Task<bool> Handle(RemoveRAMCommand request, CancellationToken cancellationToken)
        {
            EstablishConnection();
            bool res = _RAMs.Delete(request.RAMId);
            return Task.FromResult(res);
        }
    }
}
