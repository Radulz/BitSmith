using MediatR;
using PCPartsShop.Interfaces;
using PCPartsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.Commands.MOBOCommands.GetMOBO
{
    public class GetMOBOByIdCommandHandler : IRequestHandler<GetMOBOByIdCommand, MOBO>
    {
        private readonly IComponentRepository<MOBO> _MOBOs;
        public GetMOBOByIdCommandHandler(IComponentRepository<MOBO> repository)
        {
            _MOBOs = repository;
        }
        public Task<MOBO> Handle(GetMOBOByIdCommand request, CancellationToken cancellationToken)
        {
            var m = _MOBOs.GetItem(request.MOBOId);
            return Task.FromResult(m);
        }
    }
}
