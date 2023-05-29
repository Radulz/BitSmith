using MediatR;
using PCPartsShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Queries.CoolerQueries.GetCoolerById
{
    public class GetCoolerByIdQuery : IRequest<Cooler>
    {
        public Guid CoolerId { get; set; }
    }
}
