using ECommerceApp.NetFramework.BusinessLayer.Interfaces;
using ECommerceApp.NetFramework.Shared.Models;
using ECommerceApp.NetFramework.Shared.Resources;
using System.Web.Mvc;

namespace ECommerceApp.NetFramework.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public ActionResult CustomerOverview()
        {
            return View(_customerService.GetCustomerOverview());
        }

        public ActionResult AddCustomer()
        {
            ViewBag.Title = Labels.AddCustomer;
            ViewBag.Action = nameof(AddCustomer);

            return PartialView("UpsertCustomer", new CustomerViewModel());
        }

        public ActionResult EditCustomer(int id)
        {
            ViewBag.Title = Labels.EditCustomer;
            ViewBag.Action = nameof(EditCustomer);

            return PartialView("UpsertCustomer", _customerService.GetCustomer(id));
        }

        public ActionResult DeleteCustomer(int id)
        {
            return PartialView(_customerService.GetCustomer(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCustomer(CustomerViewModel viewModel)
        {
            _customerService.Add(viewModel);
            return RedirectToAction(nameof(CustomerOverview));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCustomer(CustomerViewModel viewModel)
        {
            _customerService.Update(viewModel);
            return RedirectToAction(nameof(CustomerOverview));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCustomerConfirmation(int id)
        {
            _customerService.Delete(id);
            return RedirectToAction(nameof(CustomerOverview));
        }
    }
}