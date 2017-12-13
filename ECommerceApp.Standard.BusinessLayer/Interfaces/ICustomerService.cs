using ECommerceApp.Standard.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceApp.Standard.BusinessLayer.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<CustomerViewModel> GetCustomerOverview();
    }
}
