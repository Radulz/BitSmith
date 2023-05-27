using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PCPartsShop.Domain.Dtos;
using PCPartsShop.Domain.Models;
using PCPartsShop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Queries.UserQueries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly PCPartsShopContext _context;
        private readonly IMapper _mapper;
        public GetUserByIdQueryHandler(PCPartsShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == request.UserId);
            if(user is null)
            {
                return null;
            }
            return _mapper.Map<UserDto>(user);
        }
    }
}
