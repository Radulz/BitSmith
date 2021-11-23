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

namespace PCPartsShop.Commands.GPUCommands.GetAllGPUs
{
    public class GetAllGPUsQueryHandler : IRequestHandler<GetAllGPUsQuery, IEnumerable<GPU>>
    {
        private IComponentRepository<GPU> _GPUs;

        public GetAllGPUsQueryHandler()
        {
            
        }
        private void EstablishConnection()
        {
            string connectionString = @"Server=RADULZ-DESKTOP\SQLEXPRESS;Database=Amdaris_PCPartsShop;Trusted_Connection=True;";
            var dbContext = new PCPartsShopContext(connectionString);
            dbContext.Database.EnsureCreated();
            _GPUs = new GPURepository(dbContext);

        }
        public Task<IEnumerable<GPU>> Handle(GetAllGPUsQuery request, CancellationToken cancellationToken)
        {
            EstablishConnection();
            var result = _GPUs.GetAll();
            return Task.FromResult(result);
        }
    }
}
