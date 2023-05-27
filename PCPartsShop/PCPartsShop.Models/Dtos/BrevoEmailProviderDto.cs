using PCPartsShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Domain.Dtos
{
    public class BrevoEmailProviderDto
    {
        public SenderDto Sender { get; set; }
        public List<ReceiverDto> To { get; set; }
        public string HtmlContent { get; set; }
        public string Subject { get; set; }
    }

    public class SenderDto
    {
        public string Email { get; set; }
        public string Name { get; set; }
    }
    public class ReceiverDto
    {
        public string Email { get; set; }
        public string Name { get; set; }
    }
}

