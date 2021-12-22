using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Commands.UserCommands.RemoveUser
{
    public class RemoveUserCommand : IRequest<bool>
    {
        public Guid UserId { get; set; }
    }
}
