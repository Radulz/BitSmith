﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Domain.Dtos
{
    public class UserDto
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string County { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public bool Admin { get; set; }

    }
}
