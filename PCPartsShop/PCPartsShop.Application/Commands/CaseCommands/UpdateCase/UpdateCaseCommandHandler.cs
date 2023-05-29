using MediatR;
using Microsoft.EntityFrameworkCore;
using PCPartsShop.Domain.Models;
using PCPartsShop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Commands.CaseCommands.UpdateCase
{
    public class UpdateCaseCommandHandler : IRequestHandler<UpdateCaseCommand, Case>
    {
        private readonly PCPartsShopContext _dbContext;

        public UpdateCaseCommandHandler(PCPartsShopContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Case> Handle(UpdateCaseCommand request, CancellationToken cancellationToken)
        {
            var pcCase = await _dbContext.Cases.FirstOrDefaultAsync(x => x.ComponentId == request.CaseId);

            if (pcCase == null)
            {
                return null;
            }
            
            pcCase.ComponentId = request.CaseId;
            pcCase.Make = request.Make;
            pcCase.Model = request.Model;
            pcCase.Price = request.Price;
            pcCase.Image = request.Image;
            pcCase.CaseType = request.CaseType;
            pcCase.PSUPosition = request.PSUPosition;
            pcCase.GPUMaximumLength = request.GPUMaximumLength;
            pcCase.RadiatorSupport = request.RadiatorSupport;
            pcCase.RadiatorSupportLength = request.RadiatorSupportLength;
            pcCase.CoolerMaximumHeight = request.CoolerMaximumHeight;

            _dbContext.Cases.Update(pcCase);
            await _dbContext.SaveChangesAsync();

            return pcCase;
        }
    }
}
