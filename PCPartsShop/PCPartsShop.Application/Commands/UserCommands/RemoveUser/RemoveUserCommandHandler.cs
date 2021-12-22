using MediatR;
using Microsoft.EntityFrameworkCore;
using PCPartsShop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Commands.UserCommands.RemoveUser
{
    public class RemoveUserCommandHandler : IRequestHandler<RemoveUserCommand, bool>
    {
        private readonly PCPartsShopContext _context;
        public RemoveUserCommandHandler(PCPartsShopContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(RemoveUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == request.UserId);
            if(user is null)
            {
                return false;
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
