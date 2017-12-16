using System.ComponentModel.DataAnnotations;

namespace ECommerceApp.NetFramework.Shared.Models
{
    public class CustomerViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Messages), ErrorMessageResourceName = nameof(Resources.Messages.FieldRequired))]
        public string Name { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Messages), ErrorMessageResourceName = nameof(Resources.Messages.FieldRequired))]
        public string EmailAdress { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Messages), ErrorMessageResourceName = nameof(Resources.Messages.FieldRequired))]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Messages), ErrorMessageResourceName = nameof(Resources.Messages.FieldRequired))]
        public string Street { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Messages), ErrorMessageResourceName = nameof(Resources.Messages.FieldRequired))]
        public int HouseNumber { get; set; }
        public string HouseNumberExtension { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Messages), ErrorMessageResourceName = nameof(Resources.Messages.FieldRequired))]
        public string ZipCode { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Messages), ErrorMessageResourceName = nameof(Resources.Messages.FieldRequired))]
        public string City { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Messages), ErrorMessageResourceName = nameof(Resources.Messages.FieldRequired))]
        public string Country { get; set; }
    }
}
