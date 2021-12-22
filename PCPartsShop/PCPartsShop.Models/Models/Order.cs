using PCPartsShop_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Domain.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string UserEmail { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserCounty { get; set; }
        public string UserCity { get; set; }
        public string UserAddress { get; set; }
        public double TotalPrice { get; set; }
        public bool IsShipped { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
