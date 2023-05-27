using PCPartsShop.Domain.Dtos;

namespace PCPartsShop.Domain.Models
{
    public class CompatibilityMessage
    {
        public string Message { get; set; }
        public string Summary { get; set; }
        public string Severity { get; set; }
        public FullSpecificationComponentDto Component1 { get; set; }
        public FullSpecificationComponentDto Component2 { get; set; }

        public CompatibilityMessage()
        {

        }
    }
}
