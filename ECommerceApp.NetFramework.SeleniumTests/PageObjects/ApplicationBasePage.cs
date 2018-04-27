using ECommerceApp.NetFramework.SeleniumTests.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ECommerceApp.NetFramework.SeleniumTests.PageObjects
{
    internal class ApplicationBasePage
    {
        internal SeleniumTestConfiguration TestConfiguration { get; set; }

        internal ApplicationBasePage(SeleniumTestConfiguration testConfiguration)
        {
            TestConfiguration = testConfiguration;
        }

        internal ApplicationBasePage StartApplicationUnderTest()
        {
            TestConfiguration.CurrentBrowser = StartWebdriver(TestConfiguration.BrowserIdentifier);
            TestConfiguration.CurrentBrowser.Url = TestConfiguration.StartUrl;
            TestConfiguration.CurrentBrowser.Navigate();

            return this;
        }

        internal void CloseApplicationUnderTest()
        {
            TestConfiguration.CurrentBrowser.Close();
            TestConfiguration.CurrentBrowser.Dispose();
        }

        protected IWebElement FindControlWithWaitInterval(By by)
        {
            var wait = new WebDriverWait(TestConfiguration.CurrentBrowser, new TimeSpan(0, 0, 10));
            return wait.Until(webdriver =>
               {
                   try
                   {
                       return webdriver.FindElement(by);  
                   }
                   catch (NoSuchElementException)
                   {
                       //do nothing and retry for interval
                   }
                   return null;
               });
        }

        protected ReadOnlyCollection<IWebElement> FindControlsWithWaitInterval(By by)
        {
            var wait = new WebDriverWait(TestConfiguration.CurrentBrowser, new TimeSpan(0, 0, 10));
            return wait.Until(webdriver =>
            {
                try
                {
                    return webdriver.FindElements(by);
                }
                catch (NoSuchElementException)
                {
                    //do nothing and retry for interval
                }
                return null;
            });
        }

        protected List<ReadOnlyCollection<IWebElement>> GetRowsWithCellsForTable(IWebElement table)
        {
            return table.FindElements(By.TagName(TagNameConstants.TABLE_ROW_TAGENAME))
                .Select(row => row.FindElements(By.TagName(TagNameConstants.TABLE_CELL_TAGENAME)))
                .ToList();
        }

        private IWebDriver StartWebdriver(string browserIdentifier)
        {
            switch (browserIdentifier)
            {
                case BrowserConstants.IE_BROWSER_IDENTIFIER:
                    return new InternetExplorerDriver(TestConfiguration.DriverLocation);
                case BrowserConstants.FIREFOX_BROWSER_IDENTIFIER:
                    return new FirefoxDriver(TestConfiguration.DriverLocation);
                case BrowserConstants.CHROME_BROWSER_IDENTIFIER:
                    return new ChromeDriver(TestConfiguration.DriverLocation);
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
