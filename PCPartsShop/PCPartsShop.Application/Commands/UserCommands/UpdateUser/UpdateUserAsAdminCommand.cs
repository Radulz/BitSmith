using MediatR;
using PCPartsShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Commands.UserCommands.UpdateUser
{
    public class UpdateUserAsAdminCommand : IRequest<User>
    {
        public Guid UserId { get; set; }
    }
}
