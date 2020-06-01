using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Epam.Automation.Mentoring.Mail.Autotests.WebDriver
{
    public class MyWebDriver : IWebDriver
    {
        private readonly IWebDriver webDriver;
        public string CurrentTest { get; set; }

        public MyWebDriver(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public string Url { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Title => throw new NotImplementedException();

        public string PageSource => throw new NotImplementedException();

        public string CurrentWindowHandle => throw new NotImplementedException();

        public ReadOnlyCollection<string> WindowHandles => throw new NotImplementedException();

        public void Close()
        {
            webDriver.Close();
        }

        public void Dispose()
        {
            webDriver.Dispose();
        }

        public IWebElement FindElement(By by)
        {
            WaitForIsVisible(by);
            return webDriver.FindElement(by);
        }

        public bool IsElementPresent(By by)
        {
            WaitForIsVisible(by);
            try
            {
                webDriver.FindElements(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void WaitForIsVisibleExtra(By by)
        {
            var wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, 30));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
        }

        public void WaitForIsVisible(By by)
        {
            var wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, 05));
            var element = wait.Until(condition =>
            {
                try
                {
                    var elementToBeDisplayed = webDriver.FindElement(by);
                    return elementToBeDisplayed.Displayed;
                }
               catch (StaleElementReferenceException)
                {
                    return false;
                }
               catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }

        public void WaitForElementToDisappier(By by)
        {
            var wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, 10));
            var element = wait.Until(condition =>
            {
                try
                {
                    var element = webDriver.FindElement(by);
                    return !element.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return true;
                }
                catch (StaleElementReferenceException)
                {
                    return true;
                }
            });

        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return webDriver.FindElements(by);
        }

        public IOptions Manage()
        {
           return webDriver.Manage();
        }

        public INavigation Navigate()
        {
            return webDriver.Navigate();
        }

        public void Quit()
        {
            webDriver.Quit();
        }

        public ITargetLocator SwitchTo()
        {
            throw new NotImplementedException();
        }
    }
}
