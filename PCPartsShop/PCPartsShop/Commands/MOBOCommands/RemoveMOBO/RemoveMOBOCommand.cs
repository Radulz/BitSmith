﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPartsShop.Commands.MOBOCommands.RemoveMOBO
{
    public class RemoveMOBOCommand : IRequest<bool>
    {
        public Guid MOBOId { get; set; }
    }
}
