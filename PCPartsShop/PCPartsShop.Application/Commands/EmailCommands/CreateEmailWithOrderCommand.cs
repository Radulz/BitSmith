using MediatR;
using PCPartsShop.Domain.Dtos;
using PCPartsShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Commands.EmailCommands
{
    public class CreateEmailWithOrderCommand : IRequest<BrevoAPIResponseDto>
    {
        public Order Order { get; set; }

    }
}
