using MediatR;
using PCPartsShop.Interfaces;
using PCPartsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.Commands.PSUCommands.RemovePSU
{
    public class RemovePSUCommandHandler : IRequestHandler<RemovePSUCommand, bool>
    {
        private readonly IComponentRepository<PSU> _PSUs;

        public RemovePSUCommandHandler(IComponentRepository<PSU> repository)
        {
            _PSUs = repository;
        }

        public Task<bool> Handle(RemovePSUCommand request, CancellationToken cancellationToken)
        {
            bool res = _PSUs.Delete(request.PSUId);
            return Task.FromResult(res);
        }
    }
}
