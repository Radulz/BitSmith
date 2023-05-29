using PCPartsShop.Domain.Dtos;
using PCPartsShop.Domain.Models;
using System.Collections.Generic;

namespace PCPartsShop.Application.Abstract
{
    public interface ICompatibilityChecker
    {
        public List<CompatibilityMessage> CheckCompatibility(List<FullSpecificationComponentDto> parts);
    }
}
