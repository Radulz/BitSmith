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

namespace PCPartsShop.Commands.CPUCommands.GetAllCPUs
{
    public class GetAllCPUsQueryHandler : IRequestHandler<GetAllCPUsQuery, IEnumerable<CPU>>
    {
        private IComponentRepository<CPU> _CPUs;

        public GetAllCPUsQueryHandler()
        {
            
        }
        private void EstablishConnection()
        {
            string connectionString = @"Server=RADULZ-DESKTOP\SQLEXPRESS;Database=Amdaris_PCPartsShop;Trusted_Connection=True;";
            var dbContext = new PCPartsShopContext(connectionString);
            dbContext.Database.EnsureCreated();
            _CPUs = new CPURepository(dbContext);

        }
        public Task<IEnumerable<CPU>> Handle(GetAllCPUsQuery request, CancellationToken cancellationToken)
        {
            EstablishConnection();
            var result = _CPUs.GetAll();
            return Task.FromResult(result);
        }
    }
}
