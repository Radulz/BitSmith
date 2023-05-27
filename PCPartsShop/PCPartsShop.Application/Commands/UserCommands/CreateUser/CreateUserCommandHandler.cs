using MediatR;
using PCPartsShop.Domain.Models;
using PCPartsShop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Commands.UserCommands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly PCPartsShopContext _context;
        public CreateUserCommandHandler(PCPartsShopContext context)
        {
            _context = context;
        }
        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                County = request.County,
                City = request.City,
                Address = request.Address,
                Admin = request.Admin,
            };
            var hashedPass = EncryptPassword(request.Password, user.UserId);
            user.Password = hashedPass;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        #region private methods
        private string EncryptPassword(string password, Guid Id)
        {
            var pass = password + Id.ToString();
            SHA256 encoder = SHA256.Create();
            byte[] bytes = encoder.ComputeHash(Encoding.Unicode.GetBytes(pass));
            StringBuilder builder = new();
            for (int i=0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }

            return builder.ToString();
        }
        #endregion
    }
}
