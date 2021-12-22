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

namespace PCPartsShop.Application.Queries.UserQueries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, ICollection<User>>
    {
        private readonly PCPartsShopContext _context;
        public GetAllUsersQueryHandler(PCPartsShopContext context)
        {
            _context = context;
        }
        public async Task<ICollection<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await _context.Users.ToListAsync();
        }
    }
}
