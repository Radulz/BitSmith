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

namespace PCPartsShop.Commands.PSUCommands.GetPSU
{
    public class GetPSUByIdQueryHandler : IRequestHandler<GetPSUByIdQuery, PSU>
    {
        private IComponentRepository<PSU> _PSUs;

        public GetPSUByIdQueryHandler()
        {
            
        }
        private void EstablishConnection()
        {
            string connectionString = @"Server=RADULZ-DESKTOP\SQLEXPRESS;Database=Amdaris_PCPartsShop;Trusted_Connection=True;";
            var dbContext = new PCPartsShopContext(connectionString);
            dbContext.Database.EnsureCreated();
            _PSUs = new PSURepository(dbContext);
        }

        public Task<PSU> Handle(GetPSUByIdQuery request, CancellationToken cancellationToken)
        {
            EstablishConnection();
            var psu = _PSUs.GetItem(request.PSUId);
            return Task.FromResult(psu);
        }
    }
}
