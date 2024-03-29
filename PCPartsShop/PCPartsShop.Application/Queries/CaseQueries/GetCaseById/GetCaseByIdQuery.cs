﻿using MediatR;
using PCPartsShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Queries.CaseQueries.GetCaseById
{
    public class GetCaseByIdQuery : IRequest<Case>
    {
        public Guid CaseId { get; set; }
    }
}
