using MediatR;
using Microsoft.EntityFrameworkCore;
using PCPartsShop.Domain.Models;
using PCPartsShop.Domain.Dtos;
using PCPartsShop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;

namespace PCPartsShop.Application.Commands.UserCommands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserDto>
    {
        private readonly PCPartsShopContext _context;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(PCPartsShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<UserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x=>x.UserId== request.UserId);

            if(user == null)
            {
                return null;
            }

            user.UserId = request.UserId;
            user.Email = request.Email;
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.County = request.County;
            user.City = request.City;
            user.Address = request.Address;
            user.Admin = request.Admin;
            
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return _mapper.Map<UserDto>(user);
        }
    }
}
