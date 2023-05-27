﻿using MediatR;
using PCPartsShop.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Commands.UserCommands.LoginUser
{
    public class LoginUserCommand : IRequest<LoggedUserDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
