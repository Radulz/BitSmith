using MediatR;
using PCPartsShop.Interfaces;
using PCPartsShop.Models;
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
        private readonly IComponentRepository<PSU> _PSUs;

        public GetAllPSUsQueryHandler(IComponentRepository<PSU> repository)
        {
            _PSUs = repository;
        }
        public Task<IEnumerable<PSU>> Handle(GetAllPSUsQuery request, CancellationToken cancellationToken)
        {
            var result = _PSUs.GetAll();
            return Task.FromResult(result);
        }
    }
}
