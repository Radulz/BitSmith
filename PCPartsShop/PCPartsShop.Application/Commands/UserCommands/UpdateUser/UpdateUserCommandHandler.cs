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
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, User>
    {
        private readonly PCPartsShopContext _context;
        public UpdateUserCommandHandler(PCPartsShopContext context)
        {
            _context = context;
        }
        public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var res = _context.Users.FirstOrDefaultAsync(u => u.UserId == request.UserId);
            if(res is null)
            {
                return null;
            }
            var user = new User
            {
                UserId = request.UserId,
                Email = request.Email,
                Password = request.Password,
                FirstName = request.FirstName,
                LastName = request.LastName,
                County = request.County,
                City = request.City,
                Address = request.Address,
                Admin = request.Admin,
            };
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
