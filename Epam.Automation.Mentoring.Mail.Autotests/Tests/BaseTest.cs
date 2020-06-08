using Epam.Automation.Mentoring.Mail.Autotests.WebDriver;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Epam.Automation.Mentoring.Mail.Autotests.Tests
{
    public abstract class BaseTest : IDisposable
    {
        protected MyWebDriver driver;

        public BaseTest()
        {
            driver = new MyWebDriver(new ChromeDriver());
            TestDataProvider.FetchFromXmlReader();
        }

        public void Dispose()
        {
            Thread.Sleep(3000);
            driver.Close();
        }
    }
    
}
