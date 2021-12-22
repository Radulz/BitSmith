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

namespace PCPartsShop.Application.Queries.UserQueries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly PCPartsShopContext _context;
        public GetUserByIdQueryHandler(PCPartsShopContext context)
        {
            _context = context;
        }
        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == request.UserId);
            if(user is null)
            {
                return null;
            }
            return user;
        }
    }
}
