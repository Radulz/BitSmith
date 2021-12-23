using PCPartsShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCPartsShop.WebAPI.Dtos
{
    public class GetOrderDto
    {
        public int OrderId { get; set; }
        public string UserEmail { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserCounty { get; set; }
        public string UserCity { get; set; }
        public string UserAddress { get; set; }
        public double TotalPrice { get; set; }
        public bool ShippingStatus { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
