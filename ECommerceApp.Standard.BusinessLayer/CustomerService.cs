using ECommerceApp.Standard.BusinessLayer.Interfaces;
using System;

namespace ECommerceApp.Standard.BusinessLayer
{
    public class CustomerService : ICustomerService
    {
        private readonly IECommerceDBContext _eCommerceDBContext;

        public CustomerService(IECommerceDBContext eCommerceDBContext)
        {
            _eCommerceDBContext = eCommerceDBContext;
        }

        public IEnumerable<CustomerViewModel> GetCustomerOverview()
        {
            return _eCommerceDBContext.Customer.Select(MapToCustomerViewModel().Compile());
        }

        private static Expression<Func<Customer, CustomerViewModel>> MapToCustomerViewModel()
        {
            return customer => new CustomerViewModel
            {
                Id = customer.Id,
                Name = customer.Name,
                EmailAdress = customer.EmailAdress,
                PhoneNumber = customer.PhoneNumber,
                Street = customer.Street,
                HouseNumber = customer.HouseNumber,
                HouseNumberExtension = customer.HouseNumberExtension,
                ZipCode = customer.ZipCode
            };
        }
    }
}
