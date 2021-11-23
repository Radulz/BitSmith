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

namespace PCPartsShop.Commands.PSUCommands.GetAllPSUs
{
    public class GetAllPSUsQueryHandler : IRequestHandler<GetAllPSUsQuery, IEnumerable<PSU>>
    {
        private IComponentRepository<PSU> _PSUs;

        public GetAllPSUsQueryHandler()
        {
            
        }
        private void EstablishConnection()
        {
            string connectionString = @"Server=RADULZ-DESKTOP\SQLEXPRESS;Database=Amdaris_PCPartsShop;Trusted_Connection=True;";
            var dbContext = new PCPartsShopContext(connectionString);
            dbContext.Database.EnsureCreated();
            _PSUs = new PSURepository(dbContext);
        }
        public Task<IEnumerable<PSU>> Handle(GetAllPSUsQuery request, CancellationToken cancellationToken)
        {
            EstablishConnection();
            var result = _PSUs.GetAll();
            return Task.FromResult(result);
        }
    }
}
