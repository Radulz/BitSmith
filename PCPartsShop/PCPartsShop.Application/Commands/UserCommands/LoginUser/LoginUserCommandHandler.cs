using MediatR;
using Microsoft.EntityFrameworkCore;
using PCPartsShop.Domain.Dtos;
using PCPartsShop.Domain.Models;
using PCPartsShop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Commands.UserCommands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoggedUserDto>
    {
        private readonly PCPartsShopContext _context;

        public LoginUserCommandHandler(PCPartsShopContext context)
        {
            _context = context;
        }
        public async Task<LoggedUserDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (user != null)
            {
                var hashedPass = EncryptPassword(request.Password, user.UserId);

                if(user.Password == hashedPass)
                {
                    return new LoggedUserDto { IsLoggedIn = true };
                }
            }
            return new LoggedUserDto { IsLoggedIn = false };
        }

        #region private methods
        private string EncryptPassword(string password, Guid Id)
        {
            var pass = password + Id.ToString();
            SHA256 encoder = SHA256.Create();
            byte[] bytes = encoder.ComputeHash(Encoding.Unicode.GetBytes(pass));
            StringBuilder builder = new();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }

            return builder.ToString();
        }
        #endregion
    }
}
