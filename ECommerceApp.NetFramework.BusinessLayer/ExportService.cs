using ECommerceApp.NetFramework.BusinessLayer.Interfaces;
using ECommerceApp.NetFramework.Shared.Adapters.Interfaces;
using ECommerceApp.NetFramework.Shared.Models;
using ECommmerceApp.NetFramework.DataLayer;
using ECommmerceApp.NetFramework.DataLayer.Interfaces;
using FileHelpers;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using Unity;

namespace ECommerceApp.NetFramework.BusinessLayer
{
    public class ExportService: IExportService
    {
        private readonly string _exportLocation = ConfigurationManager.AppSettings["ExportLocation"];
        private const string _customerOverviewExportName = "CustomerOverview";
        private readonly IFileHelperEngine<CustomerExport> _fileExporter;
        private readonly IECommerceDbContext _eCommerceDbContext;

        public ExportService(IFileHelperEngine<CustomerExport> fileExporter, IECommerceDbContext eCommerceDbContext)
        {
            _fileExporter = fileExporter;
            _eCommerceDbContext = eCommerceDbContext;
        }

        public IZipFile CreateCustomerOverviewZipFile()
        {
            if (!Directory.Exists(_exportLocation))
            {
                Directory.CreateDirectory(_exportLocation);
            }

            var customerOverViewExportFileLocation = $"{_exportLocation}{_customerOverviewExportName}.csv";

            CreateExportFile(customerOverViewExportFileLocation);
            return ZipExportFile(customerOverViewExportFileLocation);
        }

        private IZipFile ZipExportFile(string customerOverViewExportFileLocation)
        {
            var container = new UnityContainer();
            container.LoadConfiguration();
            var zipfile = container.Resolve<IZipFile>();
            zipfile.Name = $"{_customerOverviewExportName}.zip";
            var zipentry = zipfile.AddFile(customerOverViewExportFileLocation);
            zipentry.FileName = $"{_customerOverviewExportName}.csv";
            zipfile.Save($"{_exportLocation}{zipfile.Name}");
            return zipfile;
        }

        private void CreateExportFile(string customerOverViewExportFileLocation)
        {
            var customerData = _eCommerceDbContext.Customer
               .Where(customer => !customer.Deleted)
               .Select(MapToCustomerExportModel().Compile());

            _fileExporter.WriteFile(customerOverViewExportFileLocation, customerData);
        }

        private Expression<Func<Customer, CustomerExport>> MapToCustomerExportModel()
        {
            return customer => new CustomerExport
            {
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
