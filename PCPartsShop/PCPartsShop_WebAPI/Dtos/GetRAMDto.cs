﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCPartsShop.Dtos
{
    public class GetRAMDto
    {
        public Guid ComponentId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public string ComponentType { get; set; }
        public string Type { get; set; }
        public int Capacity { get; set; }
        public int Frequency { get; set; }
        public double Voltage { get; set; }
    }
}
