using ECommmerceApp.NetFramework.DataLayer;
using System;

namespace ECommerceApp.NetFramework.SeleniumTests.Helpers
{
    internal static class TestDataBuilder
    {
        internal static Customer CreateTestCustomer()
        {
            var uniqueIdentifier = DateTime.Now.Ticks;

            return new Customer
            {
                Name = $"TestCustomer {uniqueIdentifier}",
                Street = "Test street",
                HouseNumber = 1,
                ZipCode = "1111AA",
                PhoneNumber = "0612345678",
                City = "Test city",
                Country = "Test country",
                EmailAdress = $"info@testcustomer{uniqueIdentifier}.com"
            };
        }
    }
}
