using FileHelpers;

namespace ECommerceApp.NetFramework.Shared.Models
{
    [DelimitedRecord(";")]    
    public class CustomerExport
    {     
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public string HouseNumberExtension { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
