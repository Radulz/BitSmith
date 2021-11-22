using MediatR;
using PCPartsShop.Interfaces;
using PCPartsShop.Models;
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
        private readonly IComponentRepository<PSU> _PSUs;

        public GetPSUByIdQueryHandler(IComponentRepository<PSU> repository)
        {
            _PSUs = repository;
        }

        public Task<PSU> Handle(GetPSUByIdQuery request, CancellationToken cancellationToken)
        {
            var psu = _PSUs.GetItem(request.PSUId);
            return Task.FromResult(psu);
        }
    }
}
