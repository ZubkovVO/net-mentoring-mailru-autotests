using Epam.Automation.Mentoring.Mail.Autotests.Utility;
using Epam.Automation.Mentoring.Mail.Autotests.WebDriver;
using log4net;
using System;
using System.IO;
using System.Threading;

namespace Epam.Automation.Mentoring.Mail.Autotests.Tests
{
    public abstract class BaseTest : IDisposable
    {
        protected static MyWebDriver driver = MyWebDriver.Instance;

        public string testVar;

        public BaseTest()
        {
            driver = MyWebDriver.Instance; //new MyWebDriver();
            driver.Navigate().GoToUrl("https://www.mail.ru");          
        }

        protected void UITest(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                var screenshotPath = ScreenshotTaker.TakeScreenshot(Path.Combine(Environment.CurrentDirectory, "Screenshots"), MyWebDriver.GetDriver(), testVar);
                Logger.Log.Error("The test: " + testVar + " failed during execution, the screenshot can be found here: " + screenshotPath);
                Logger.Log.Error("Failing cause: " + ex);
                // This would be a good place to log the exception message and
                // save together with the screenshot

                throw;
            }
        }

        public void Dispose()
        {
            Thread.Sleep(3000);
            driver.Quit();            
        }
    }

}
