using MediatR;
using PCPartsShop_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Queries.MOBOQueries.GetAllMOBOs
{
    public class GetAllMOBOsQuery : IRequest<IEnumerable<MOBO>>
    {
    }
}
