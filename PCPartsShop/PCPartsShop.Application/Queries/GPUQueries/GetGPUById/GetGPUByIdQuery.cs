using MediatR;
using PCPartsShop_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Queries.GPUQueries.GetGPUById
{
    public class GetGPUByIdQuery : IRequest<GPU>
    {
        public Guid GPUId { get; set; }
    }
}
