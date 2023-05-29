using MediatR;
using PCPartsShop.Application.Abstract;
using PCPartsShop.Domain.Dtos;
using PCPartsShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Commands.CompatibilityCommands
{
    public class CreateCompatibilityCommandHandler : IRequestHandler<CreateCompatibilityCommand, List<CompatibilityMessage>>
    {
        private readonly ICompatibilityChecker _compatibilityChecker;

        public CreateCompatibilityCommandHandler(ICompatibilityChecker compatibilityChecker)
        {
            _compatibilityChecker = compatibilityChecker;
        }
        public async Task<List<CompatibilityMessage>> Handle(CreateCompatibilityCommand request, CancellationToken cancellationToken)
        {
            var messages = _compatibilityChecker.CheckCompatibility(request.Parts);
            return await Task.FromResult(messages);
        }
    }
}
