using System.Collections.Generic;
using ECommerceApp.NetFramework.Shared.Models;

namespace ECommerceApp.NetFramework.BusinessLayer.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<CustomerViewModel> GetCustomerOverview();

        CustomerViewModel GetCustomer(int id);

        void Add(CustomerViewModel viewModel);

        void Update(CustomerViewModel viewModel);

        void Delete(int id);
    }
}