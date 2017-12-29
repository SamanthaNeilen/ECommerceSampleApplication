using ECommerceApp.NetFramework.BusinessLayer.Tests.MockObjects;
using ECommerceApp.NetFramework.Shared.Adapters.Interfaces;
using ECommerceApp.NetFramework.Shared.Models;
using ECommmerceApp.NetFramework.DataLayer;
using ECommmerceApp.NetFramework.DataLayer.Interfaces;
using FileHelpers;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace ECommerceApp.NetFramework.BusinessLayer.Tests
{
    public class ExportServiceTests
    {
        private readonly string _exportLocation = ConfigurationManager.AppSettings["ExportLocation"];
        private const string _customerOverviewExportName = "CustomerOverview";
        private string _customerOverViewExportFileLocation;
        private Mock<IFileHelperEngine<CustomerExport>> _mockFileExporter;
        private IECommerceDbContext _eCommerceDbContext;
        private ExportService _exportService;

        [SetUp]
        public void Initialize()
        {
            _customerOverViewExportFileLocation = $"{_exportLocation}{_customerOverviewExportName}.csv";
            _eCommerceDbContext = new MockECommerceDbContext();
            _mockFileExporter = new Mock<IFileHelperEngine<CustomerExport>>();
            _exportService = new ExportService(_mockFileExporter.Object, _eCommerceDbContext);

            _eCommerceDbContext.Customer.Add(new Customer { Id = 1, Name = "Test customer 1", Deleted = false });
            _eCommerceDbContext.Customer.Add(new Customer { Id = 2, Name = "Test customer 2", Deleted = true });
            _eCommerceDbContext.Customer.Add(new Customer { Id = 3, Name = "Test customer 3", Deleted = false });

            _mockFileExporter.Setup(exporter => exporter.WriteFile(_customerOverViewExportFileLocation, NonDeletedCustomers())).Verifiable();
        }


        [Test]
        public void CreateCustomerOverviewZipFile_Should_Export_Non_Deleted_Customers()
        {
            // ACT
            var result = _exportService.CreateCustomerOverviewZipFile();

            // ASSERT
            Assert.IsInstanceOf<IZipFile>(result);
            _mockFileExporter.Verify(exporter => exporter.WriteFile(_customerOverViewExportFileLocation, NonDeletedCustomers()));
            var mockZipfile = result as MockZipFile;
            Assert.AreEqual(1, mockZipfile.ZipEntries.Count);
            Assert.AreEqual($"{_customerOverviewExportName}.csv", mockZipfile.ZipEntries[0].FileName);
            Assert.AreEqual(_customerOverViewExportFileLocation, mockZipfile.ZipEntries[0].Location);
        }

        private IEnumerable<CustomerExport> NonDeletedCustomers()
        {
            return It.Is<IEnumerable<CustomerExport>>(customerExports =>
                            customerExports.Any(export => export.Name == "Test customer 1")
                            && customerExports.Any(export => export.Name == "Test customer 3")
                            && !customerExports.Any(export => export.Name == "Test customer 2")
                        );
        }
    }
}
