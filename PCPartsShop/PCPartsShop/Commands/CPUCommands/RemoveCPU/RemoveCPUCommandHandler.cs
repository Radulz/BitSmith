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

namespace PCPartsShop.Commands.CPUCommands.RemoveCPU
{
    public class RemoveCPUCommandHandler : IRequestHandler<RemoveCPUCommand, bool>
    {
        private IComponentRepository<CPU> _CPUs;
        public RemoveCPUCommandHandler()
        {
            
        }
        private void EstablishConnection()
        {
            string connectionString = @"Server=RADULZ-DESKTOP\SQLEXPRESS;Database=Amdaris_PCPartsShop;Trusted_Connection=True;";
            var dbContext = new PCPartsShopContext(connectionString);
            dbContext.Database.EnsureCreated();
            _CPUs = new CPURepository(dbContext);

        }
        public Task<bool> Handle(RemoveCPUCommand request, CancellationToken cancellationToken)
        {
            EstablishConnection();
            bool res = _CPUs.Delete(request.CPUId);
            return Task.FromResult(res);
        }
    }
}
