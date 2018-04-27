using ECommerceApp.NetFramework.BusinessLayer.Interfaces;
using ECommerceApp.NetFramework.Shared.Models;
using ECommerceApp.NetFramework.Shared.Resources;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace ECommerceApp.NetFramework.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IExportService _exportService;

        public CustomerController(ICustomerService customerService, IExportService exportService)
        {
            _customerService = customerService;
            _exportService = exportService;
        }

        public ActionResult CustomerOverview()
        {
            ViewBag.EnableExport = bool.Parse(ConfigurationManager.AppSettings["EnableExport"]);
            return View(_customerService.GetCustomerOverview());
        }

        public ActionResult AddCustomer()
        {
            ViewBag.Title = Labels.AddCustomer;
            ViewBag.Action = nameof(AddCustomer);

            return View("UpsertCustomer", new CustomerViewModel());
        }

        public ActionResult EditCustomer(int id)
        {
            ViewBag.Title = Labels.EditCustomer;
            ViewBag.Action = nameof(EditCustomer);

            return View("UpsertCustomer", _customerService.GetCustomer(id));
        }

        public ActionResult DeleteCustomer(int id)
        {
            return View(_customerService.GetCustomer(id));
        }

        /// <summary>
        /// Method and export is disabled in view with feature flag in config. Export relies on library needing local filesystem.
        /// Used exportservice to demonstrate writing unittests based on 3rd party library
        /// </summary>
        public ActionResult Export()
        {
            var zipfile = _exportService.CreateCustomerOverviewZipFile();
            Response.BufferOutput = false; // to avoid IIS error for file > 1 GB

            return new FileContentResult(System.IO.File.ReadAllBytes(zipfile.Name), MimeMapping.GetMimeMapping(zipfile.Name))
            {
                FileDownloadName = HttpUtility.UrlEncode(Path.GetFileName(zipfile.Name))
            };
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCustomer(CustomerViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _customerService.Add(viewModel);
                return RedirectToAction(nameof(CustomerOverview));
            }

            ViewBag.Title = Labels.AddCustomer;
            ViewBag.Action = nameof(AddCustomer);

            return View("UpsertCustomer", viewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCustomer(CustomerViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _customerService.Update(viewModel);
                return RedirectToAction(nameof(CustomerOverview));
            }

            ViewBag.Title = Labels.EditCustomer;
            ViewBag.Action = nameof(EditCustomer);

            return View("UpsertCustomer", viewModel);
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