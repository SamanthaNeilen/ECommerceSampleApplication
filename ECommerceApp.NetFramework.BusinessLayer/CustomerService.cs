using ECommerceApp.NetFramework.BusinessLayer.Interfaces;
using ECommerceApp.NetFramework.Shared.Models;
using ECommmerceApp.NetFramework.DataLayer;
using ECommmerceApp.NetFramework.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ECommerceApp.NetFramework.BusinessLayer
{
    public class CustomerService : ICustomerService
    {
        private readonly IECommerceDbContext _eCommerceDbContext;

        public CustomerService(IECommerceDbContext eCommerceDbContext)
        {
            _eCommerceDbContext = eCommerceDbContext;
        }

        public IEnumerable<CustomerViewModel> GetCustomerOverview()
        {
            return _eCommerceDbContext.Customer
                .Where(customer => !customer.Deleted)
                .Select(MapToCustomerViewModel().Compile());
        }

        public CustomerViewModel GetCustomer(int id)
        {
            return _eCommerceDbContext.Customer.Where(customer => customer.Id == id).Select(MapToCustomerViewModel().Compile()).Single();
        }        

        public void Add(CustomerViewModel viewModel)
        {
            var newCustomer = new Customer();
            MapToCustomerData(newCustomer, viewModel);
            _eCommerceDbContext.Customer.Add(newCustomer);
            _eCommerceDbContext.SaveChanges();
        }       

        public void Update(CustomerViewModel viewModel)
        {
            var customer = _eCommerceDbContext.Customer.Single(customerData => customerData.Id == viewModel.Id);
            MapToCustomerData(customer, viewModel);
            _eCommerceDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var customer = _eCommerceDbContext.Customer.Single(customerData => customerData.Id == id);
            customer.Deleted = true;
            _eCommerceDbContext.SaveChanges();
        }

        private void MapToCustomerData(Customer customer, CustomerViewModel viewModel)
        {
            customer.Name = viewModel.Name;
            customer.EmailAdress = viewModel.EmailAddress;
            customer.PhoneNumber = viewModel.PhoneNumber;
            customer.Street = viewModel.Street;
            customer.HouseNumber = viewModel.HouseNumber;
            customer.HouseNumberExtension = viewModel.HouseNumberExtension;
            customer.ZipCode = viewModel.ZipCode;
            customer.City = viewModel.City;
            customer.Country = viewModel.Country;
        }

        private Expression<Func<Customer, CustomerViewModel>> MapToCustomerViewModel()
        {
            return customer => new CustomerViewModel
            {
                Id = customer.Id,
                Name = customer.Name,
                EmailAddress = customer.EmailAdress,
                PhoneNumber = customer.PhoneNumber,
                Street = customer.Street,
                HouseNumber = customer.HouseNumber,
                HouseNumberExtension = customer.HouseNumberExtension,
                ZipCode = customer.ZipCode,
                City = customer.City,
                Country = customer.Country
            };
        }
    }
}
