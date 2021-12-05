using MediatR;
using PCPartsShop_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Queries.PSUQueries.GetPSUById
{
    public class GetPSUByIdQuery : IRequest<PSU>
    {
        public Guid PSUId { get; set; }

    }
}
