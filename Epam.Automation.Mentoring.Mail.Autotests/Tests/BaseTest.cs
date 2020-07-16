using Epam.Automation.Mentoring.Mail.Autotests.WebDriver;
using System;
using System.Threading;

namespace Epam.Automation.Mentoring.Mail.Autotests.Tests
{
    public abstract class BaseTest : IDisposable
    {
        protected static MyWebDriver driver = MyWebDriver.Instance;

        public BaseTest()
        {
            driver = MyWebDriver.Instance; //new MyWebDriver();
            TestDataProvider.FetchFromXmlReader();
            driver.Navigate().GoToUrl("https://www.mail.ru");
        }

        public void Dispose()
        {
            Thread.Sleep(3000);
            driver.Quit();
        }
    }

}
