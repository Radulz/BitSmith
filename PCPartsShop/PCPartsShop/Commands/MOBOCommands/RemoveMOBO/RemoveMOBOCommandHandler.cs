using MediatR;
using PCPartsShop.Interfaces;
using PCPartsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.Commands.MOBOCommands.RemoveMOBO
{
    public class RemoveMOBOCommandHandler : IRequestHandler<RemoveMOBOCommand, bool>
    {
        private readonly IComponentRepository<MOBO> _MOBOs;
        public RemoveMOBOCommandHandler(IComponentRepository<MOBO> repository)
        {
            _MOBOs = repository;
        }
        public Task<bool> Handle(RemoveMOBOCommand request, CancellationToken cancellationToken)
        {
            bool res = _MOBOs.Delete(request.MOBOId);
            return Task.FromResult(res);
        }
    }
}
