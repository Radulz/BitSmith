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

namespace PCPartsShop.Application.Queries.UserQueries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, ICollection<UserDto>>
    {
        private readonly PCPartsShopContext _context;
        private readonly IMapper _mapper;

        public GetAllUsersQueryHandler(PCPartsShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ICollection<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            List<UserDto> customers = new();
            var users = await _context.Users.ToListAsync(cancellationToken);
            foreach (var u in users)
            {
                var customer = _mapper.Map<UserDto>(u);
                customers.Add(customer);
            }

            return customers;
        }
    }
}
