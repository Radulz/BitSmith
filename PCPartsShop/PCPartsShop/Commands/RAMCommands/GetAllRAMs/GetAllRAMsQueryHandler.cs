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

namespace PCPartsShop.Commands.RAMCommands.GetAllRAMs
{
    public class GetAllRAMsQueryHandler : IRequestHandler<GetAllRAMsQuery, IEnumerable<RAM>>
    {
        private IComponentRepository<RAM> _RAMs;

        public GetAllRAMsQueryHandler()
        {
            
        }
        private void EstablishConnection()
        {
            string connectionString = @"Server=RADULZ-DESKTOP\SQLEXPRESS;Database=Amdaris_PCPartsShop;Trusted_Connection=True;";
            var dbContext = new PCPartsShopContext(connectionString);
            dbContext.Database.EnsureCreated();
            _RAMs = new RAMRepository(dbContext);
        }
        public Task<IEnumerable<RAM>> Handle(GetAllRAMsQuery request, CancellationToken cancellationToken)
        {
            EstablishConnection();
            var result = _RAMs.GetAll();
            return Task.FromResult(result);
        }
    }
}
