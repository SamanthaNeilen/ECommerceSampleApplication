using ECommerceApp.NetFramework.SeleniumTests.Helpers;
using Data = ECommmerceApp.NetFramework.DataLayer;
using OpenQA.Selenium;
using System.Linq;

namespace ECommerceApp.NetFramework.SeleniumTests.PageObjects.Customer
{
    internal class CustomerOverviewPage : ApplicationBasePage
    {
        private const string HEADER_ID = "customerOverviewHeader";
        private const string ADD_BUTTON_ID = "addCustomerLink";
        private const string TABLE_ID = "customerOverviewTable";

        internal CustomerOverviewPage(SeleniumTestConfiguration testConfiguration) : base(testConfiguration)
        {

        }

        internal bool CurrentPageIsExpectedPage()
        {
            return FindControlWithWaitInterval(By.Id(HEADER_ID)).Displayed;
        }

        internal bool AddButtonDisplayed()
        {
            var linkButton = FindControlWithWaitInterval(By.Id(ADD_BUTTON_ID));
            return linkButton.Displayed && linkButton.Enabled;
        }

        internal bool CustomerRowDisplayed(Data.Customer customer)
        {
            var customerOverviewTable = FindControlWithWaitInterval(By.Id(TABLE_ID));
            var cellsForRows = GetRowsWithCellsForTable(customerOverviewTable);
            var customerRow = cellsForRows.Single(row => row.Any(cell => cell.Text == customer.Name));

            return customerRow.Any(cell => cell.Text == customer.EmailAdress)
                && customerRow.Any(cell => cell.Text == customer.PhoneNumber)
                && customerRow.Any(cell => cell.Text == customer.Street)
                && customerRow.Any(cell => cell.Text == customer.HouseNumber.ToString())
                && customerRow.Any(cell => cell.Text == (customer.HouseNumberExtension ?? string.Empty))
                && customerRow.Any(cell => cell.Text == customer.ZipCode);
        }
    }
}
