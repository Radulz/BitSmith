using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PCPartsShop.Domain.Dtos;
using PCPartsShop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Commands.UserCommands.UpdateUser
{
    public class UpdateUserAsAdminCommandHandler : IRequestHandler<UpdateUserAsAdminCommand, UserDto>
    {
        private readonly PCPartsShopContext _context;
        private readonly IMapper _mapper;
        public UpdateUserAsAdminCommandHandler(PCPartsShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<UserDto> Handle(UpdateUserAsAdminCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == request.UserId);
            if(user is null)
            {
                return null;
            }
            user.Admin = true;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return _mapper.Map<UserDto>(user);
        }
    }
}
