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

namespace PCPartsShop.Commands.CPUCommands.GetCPU
{
    public class GetCPUByIdQueryHandler : IRequestHandler<GetCPUByIdQuery, CPU>
    {
        private IComponentRepository<CPU> _CPUs;
        public GetCPUByIdQueryHandler()
        {
            
        }
        private void EstablishConnection()
        {
            string connectionString = @"Server=RADULZ-DESKTOP\SQLEXPRESS;Database=Amdaris_PCPartsShop;Trusted_Connection=True;";
            var dbContext = new PCPartsShopContext(connectionString);
            dbContext.Database.EnsureCreated();
            _CPUs = new CPURepository(dbContext);

        }
        public Task<CPU> Handle(GetCPUByIdQuery request, CancellationToken cancellationToken)
        {
            EstablishConnection();
            var cpu = _CPUs.GetItem(request.CPUId);
            return Task.FromResult(cpu);
        }
    }
}
