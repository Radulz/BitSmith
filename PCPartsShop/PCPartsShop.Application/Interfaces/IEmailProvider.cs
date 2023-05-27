using PCPartsShop.Domain.Dtos;
using PCPartsShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Interfaces
{
    public interface IEmailProvider
    {
        public Task<BrevoAPIResponseDto> SendEmail(BrevoEmailProviderDto email);
    }
}
