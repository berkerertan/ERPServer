
using ERPServer.Domain.Abstractions;

namespace ERPServer.Domain.Entities
{
    public class Customer:Entity
    {
        public string Name { get; set; } = string.Empty;
        public string TaxDepoartment { get; set; } = string.Empty;
        public string TaxNumber { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Town { get; set; } = string.Empty;
        public string FullAddress { get; set; } = string.Empty;
    }
}
