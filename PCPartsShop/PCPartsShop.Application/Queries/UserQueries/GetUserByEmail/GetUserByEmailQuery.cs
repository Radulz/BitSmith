﻿using MediatR;
using PCPartsShop.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Queries.UserQueries.GetUserByEmail
{
    public class GetUserByEmailQuery : IRequest<UserDto>
    {
        public string Email { get; set; }
    }
}
