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
    public class GetPSUByIdCommandHandler : IRequestHandler<GetPSUByIdCommand, PSU>
    {
        private readonly IComponentRepository<PSU> _PSUs;

        public GetPSUByIdCommandHandler(IComponentRepository<PSU> repository)
        {
            _PSUs = repository;
        }

        public Task<PSU> Handle(GetPSUByIdCommand request, CancellationToken cancellationToken)
        {
            var psu = _PSUs.GetItem(request.PSUId);
            return Task.FromResult(psu);
        }
    }
}
