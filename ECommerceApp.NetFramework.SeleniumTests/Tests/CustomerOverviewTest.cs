using ECommerceApp.NetFramework.SeleniumTests.Helpers;
using ECommerceApp.NetFramework.SeleniumTests.PageObjects;
using ECommerceApp.NetFramework.SeleniumTests.PageObjects.Customer;
using ECommmerceApp.NetFramework.DataLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ECommerceApp.NetFramework.SeleniumTests.Tests
{
    [TestClass]
    public class CustomerOverviewTest
    {
        public TestContext TestContext { get; set; }
        private ECommerceDbContext _dbContext;
        private Customer _customerTestData;
        private ApplicationBasePage _applicationUnderTest;


        [TestInitialize]
        public void Initialize() {
            _dbContext = new ECommerceDbContext();
            CreateCustomerTestData();

            var testConfiguration = new SeleniumTestConfiguration(TestContext.DataRow);
            _applicationUnderTest = new ApplicationBasePage(testConfiguration);
            _applicationUnderTest.StartApplicationUnderTest();
        }        

        [TestCleanup]
        public void CleanUp() {
            CleanupTestData();
            _applicationUnderTest.CloseApplicationUnderTest();
        }        

        [TestMethod, DataSource("Browsers")]
        public void CustomerOverview_Should_Show_Expected_Customer()
        {
            //ARRANGE
            var customerOverview = new CustomerOverviewPage(_applicationUnderTest.TestConfiguration);

            //ASSERT
            customerOverview.CurrentPageIsExpectedPage();
            customerOverview.AddButtonDisplayed();
            customerOverview.CustomerRowDisplayed(_customerTestData);
        }

        //TODO CLICK DELETE FOR CUSTOMER NAVIGATES TO REMOVE

        //TODO CLICK EDIT FOR CUSTOMER NAVIGATES TO EDIT

        //TODO CLICK ADD NAVIGATES TO ADD

        private void CreateCustomerTestData()
        {
            _customerTestData = TestDataBuilder.CreateTestCustomer();
            _dbContext.Customer.Add(_customerTestData);
            _dbContext.SaveChanges();
        }
        private void CleanupTestData()
        {
            if (_customerTestData != null)
            {
                _dbContext.Customer.Remove(_customerTestData);
                _dbContext.SaveChanges();
            }
        }

    }
}
