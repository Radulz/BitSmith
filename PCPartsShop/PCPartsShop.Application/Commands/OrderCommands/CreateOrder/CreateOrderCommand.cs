using MediatR;
using PCPartsShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Commands.OrderCommands.CreateOrder
{
    public class CreateOrderCommand : IRequest<Order>
    {
        public string UserEmail { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserCounty { get; set; }
        public string UserCity { get; set; }
        public string UserAddress { get; set; }
        public double TotalPrice { get; set; }
    }
}
