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

namespace PCPartsShop.Application.Queries.UserQueries.GetUserByEmail
{
    public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, UserDto>
    {
        private readonly PCPartsShopContext _context;
        private readonly IMapper _mapper;
        public GetUserByEmailQueryHandler(PCPartsShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<UserDto> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            if(user == null)
            {
                return null;
            }
            return _mapper.Map<UserDto>(user);
        }
    }
}
