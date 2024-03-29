﻿using MediatR;
using PCPartsShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Queries.SSDQueries.GetSSDById
{
    public class GetSSDByIdQuery : IRequest<SSD>
    {
        public Guid SSDId { get; set; }
    }
}
