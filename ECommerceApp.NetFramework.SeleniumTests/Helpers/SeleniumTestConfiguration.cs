using OpenQA.Selenium;
using System.Configuration;
using System.Data;

namespace ECommerceApp.NetFramework.SeleniumTests.Helpers
{
    internal class SeleniumTestConfiguration
    {
        internal string DriverLocation { get { return ConfigurationManager.AppSettings["DriverLocation"]; } }
        internal string ApplicationBaseUrl { get { return ConfigurationManager.AppSettings["ApplicationBaseUrl"]; } }
        internal string BrowserIdentifier { get; set; }
        internal IWebDriver CurrentBrowser { get; set; }
        internal string StartUrl { get; set; }

        internal SeleniumTestConfiguration(DataRow dataRow)
        {
            BrowserIdentifier = BrowserConstants.CHROME_BROWSER_IDENTIFIER;
            if (dataRow != null)
            {
                BrowserIdentifier = dataRow[0].ToString();
            }
            StartUrl = ApplicationBaseUrl;
        }
    }
}
