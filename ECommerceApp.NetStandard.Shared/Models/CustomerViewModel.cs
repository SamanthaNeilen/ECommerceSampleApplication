using ECommerceApp.NetStandard.Shared.Constants;
using ECommerceApp.NetStandard.Shared.Resources;
using System.ComponentModel.DataAnnotations;

namespace ECommerceApp.NetStandard.Shared.Models
{
    public class CustomerViewModel
    {
        public int Id { get; set; }

        //[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.FieldRequired))]
        //[MaxLength(250, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.MaxLength))]
        public string Name { get; set; }

        //[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.FieldRequired))]
        //[MaxLength(250, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.MaxLength))]
        //[RegularExpression(RegularExpressions.EmailRegularExpression, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.InvalidEmailAdress))]
        public string EmailAdress { get; set; }

        //[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.FieldRequired))]
        //[MaxLength(20, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.MaxLength))]
        //[RegularExpression(RegularExpressions.DutchPhoneNumberRegularExpression, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.InvalidPhonenumber))]
        public string PhoneNumber { get; set; }

        [MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.MaxLength))]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.FieldRequired))]
        public string Street { get; set; }

        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.FieldRequired))]
        [RegularExpression(RegularExpressions.NumericRegularExpression, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.InvalidHouseNumber))]
        public int HouseNumber { get; set; }

        [MaxLength(10, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.MaxLength))]
        public string HouseNumberExtension { get; set; }

        [MaxLength(10, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.MaxLength))]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.FieldRequired))]
        [RegularExpression(RegularExpressions.DutchZipCodeRegularExpression, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.InvalidZipCode))]
        public string ZipCode { get; set; }

        [MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.MaxLength))]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.FieldRequired))]
        public string City { get; set; }

        [MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.MaxLength))]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.FieldRequired))]
        public string Country { get; set; }
    }
}
