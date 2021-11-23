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

namespace PCPartsShop.Commands.MOBOCommands.GetMOBO
{
    public class GetMOBOByIdQueryHandler : IRequestHandler<GetMOBOByIdQuery, MOBO>
    {
        private IComponentRepository<MOBO> _MOBOs;
        public GetMOBOByIdQueryHandler()
        {
            
        }
        private void EstablishConnection()
        {
            string connectionString = @"Server=RADULZ-DESKTOP\SQLEXPRESS;Database=Amdaris_PCPartsShop;Trusted_Connection=True;";
            var dbContext = new PCPartsShopContext(connectionString);
            dbContext.Database.EnsureCreated();
            _MOBOs = new MOBORepository(dbContext);
        }
        public Task<MOBO> Handle(GetMOBOByIdQuery request, CancellationToken cancellationToken)
        {
            EstablishConnection();
            var m = _MOBOs.GetItem(request.MOBOId);
            return Task.FromResult(m);
        }
    }
}
