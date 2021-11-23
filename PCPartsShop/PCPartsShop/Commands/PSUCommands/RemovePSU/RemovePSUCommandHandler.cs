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

namespace PCPartsShop.Commands.PSUCommands.RemovePSU
{
    public class RemovePSUCommandHandler : IRequestHandler<RemovePSUCommand, bool>
    {
        private IComponentRepository<PSU> _PSUs;

        public RemovePSUCommandHandler()
        {
            
        }
        private void EstablishConnection()
        {
            string connectionString = @"Server=RADULZ-DESKTOP\SQLEXPRESS;Database=Amdaris_PCPartsShop;Trusted_Connection=True;";
            var dbContext = new PCPartsShopContext(connectionString);
            dbContext.Database.EnsureCreated();
            _PSUs = new PSURepository(dbContext);
        }

        public Task<bool> Handle(RemovePSUCommand request, CancellationToken cancellationToken)
        {
            EstablishConnection();
            bool res = _PSUs.Delete(request.PSUId);
            return Task.FromResult(res);
        }
    }
}
