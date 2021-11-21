﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Commands.GPUCommands.UpdateGPU
{
    public class UpdateGPUCommand : IRequest<bool>
    {
        public Guid GPUId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public int Freq { get; set; }
        public int Memory { get; set; }
        public string MemoryType { get; set; }
        public int Tech { get; set; }
        public int PowerC { get; set; }
        public int Length { get; set; }
    }
}
