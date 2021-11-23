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

namespace PCPartsShop.Commands.MOBOCommands.GetAllMOBOs
{
    public class GetAllMOBOsQueryHandler : IRequestHandler<GetAllMOBOsQuery, IEnumerable<MOBO>>
    {
        private IComponentRepository<MOBO> _MOBOs;

        public GetAllMOBOsQueryHandler()
        {
            
        }
        private void EstablishConnection()
        {
            string connectionString = @"Server=RADULZ-DESKTOP\SQLEXPRESS;Database=Amdaris_PCPartsShop;Trusted_Connection=True;";
            var dbContext = new PCPartsShopContext(connectionString);
            dbContext.Database.EnsureCreated();
            _MOBOs = new MOBORepository(dbContext);
        }
        public Task<IEnumerable<MOBO>> Handle(GetAllMOBOsQuery request, CancellationToken cancellationToken)
        {
            EstablishConnection();
            var result = _MOBOs.GetAll();
            return Task.FromResult(result);
        }
    }
}
