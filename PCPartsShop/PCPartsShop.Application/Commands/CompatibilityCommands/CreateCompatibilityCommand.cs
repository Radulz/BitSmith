using MediatR;
using PCPartsShop.Domain.Dtos;
using PCPartsShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Commands.CompatibilityCommands
{
    public class CreateCompatibilityCommand : IRequest<List<CompatibilityMessage>>
    {
        public List<FullSpecificationComponentDto> Parts { get; set; }
    }
}
