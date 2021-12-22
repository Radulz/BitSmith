using MediatR;
using Microsoft.EntityFrameworkCore;
using PCPartsShop.Domain.Models;
using PCPartsShop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Commands.UserCommands.UpdateUser
{
    public class UpdateUserAsAdminCommandHandler : IRequestHandler<UpdateUserAsAdminCommand, User>
    {
        private readonly PCPartsShopContext _context;
        public UpdateUserAsAdminCommandHandler(PCPartsShopContext context)
        {
            _context = context;
        }
        public async Task<User> Handle(UpdateUserAsAdminCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == request.UserId);
            if(user is null)
            {
                return null;
            }
            user.Admin = true;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
