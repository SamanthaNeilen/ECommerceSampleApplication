using ECommerceApp.NetFramework.BusinessLayer.Tests.MockObjects;
using ECommerceApp.NetFramework.Shared.Models;
using ECommmerceApp.NetFramework.DataLayer;
using ECommmerceApp.NetFramework.DataLayer.Interfaces;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceApp.NetFramework.BusinessLayer.Tests
{
    public class CustomerServiceTests
    {
        private IECommerceDbContext _eCommerceDbContext;
        private CustomerService _customerService;

        [SetUp]
        public void Initialize()
        {
            _eCommerceDbContext = new MockECommerceDbContext();
            _customerService = new CustomerService(_eCommerceDbContext);

            _eCommerceDbContext.Customer.Add(new Customer { Id = 1, Name = "Test customer 1", Deleted = false });
            _eCommerceDbContext.Customer.Add(new Customer { Id = 2, Name = "Test customer 2", Deleted = true });
            _eCommerceDbContext.Customer.Add(new Customer { Id = 3, Name = "Test customer 3", Deleted = false });
        }

        [Test]
        public void GetCustomerOverview_Should_Return_Non_Deleted_Customers()
        {
            // ACT
            var result = _customerService.GetCustomerOverview();

            // ASSERT
            Assert.IsInstanceOf<IEnumerable<CustomerViewModel>>(result);            
            Assert.IsTrue(result.Any(e => e.Id == 1));
            Assert.IsFalse(result.Any(e => e.Id == 2));
            Assert.IsTrue(result.Any(e => e.Id == 3));
        }

        [Test]
        public void Add_Given_CustomerViewModel_Should_Insert_Customer()
        {
            // ARRANGE
            var newCustomer = new CustomerViewModel { Id = 0, Name = "blabla"};

            // ACT
            _customerService.Add(newCustomer);

            // ASSERT
            Assert.AreEqual(1, (_eCommerceDbContext as MockECommerceDbContext).SaveChangesCount);
            Assert.IsNotNull(_eCommerceDbContext.Customer.SingleOrDefault(customer => customer.Name == newCustomer.Name));
        }

        [Test]
        public void Update_Given_CustomerViewModel_Should_Update_Customer()
        {
            // ARRANGE
            var existingCustomer = new CustomerViewModel { Id = 1, Name = "blabla" };

            // ACT
            _customerService.Update(existingCustomer);

            // ASSERT
            Assert.AreEqual(1, (_eCommerceDbContext as MockECommerceDbContext).SaveChangesCount);
            Assert.IsNotNull(_eCommerceDbContext.Customer.SingleOrDefault(customer => customer.Name == existingCustomer.Name && customer.Id == existingCustomer.Id));
        }
        [Test]
        public void Delete_Given_CustomerId_Should_Mark_Customer_As_Deleted()
        {
            // arrange
            const int customerId = 1;
            var existingCustomer = _eCommerceDbContext.Customer.Single(customer => customer.Id == customerId);

            // act
            _customerService.Delete(customerId);

            // assert
            Assert.AreEqual(1, (_eCommerceDbContext as MockECommerceDbContext).SaveChangesCount);
            Assert.IsTrue(existingCustomer.Deleted);
        }

    }
}
