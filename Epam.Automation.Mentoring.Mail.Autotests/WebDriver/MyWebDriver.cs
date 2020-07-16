using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;

namespace Epam.Automation.Mentoring.Mail.Autotests.WebDriver
{
    public class MyWebDriver : IWebDriver
    {
        private static MyWebDriver _currentInstance;
        private static IWebDriver webDriver; //public readonly
        public static BrowserFactory.BrowserType CurrentBrowser;
        private static string _browser;

        public string CurrentTest { get; set; }

        private MyWebDriver()
        {
            InitParamas();
            webDriver = BrowserFactory.GetDriver(CurrentBrowser);
        }

        private static void InitParamas()
        {
            _browser = Configuration.Browser;
            Enum.TryParse(_browser, out CurrentBrowser);
        }

        public static MyWebDriver Instance => _currentInstance ?? (_currentInstance = new MyWebDriver());

        public string Url { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Title => throw new NotImplementedException();

        public string PageSource => throw new NotImplementedException();

        public string CurrentWindowHandle => throw new NotImplementedException();

        public ReadOnlyCollection<string> WindowHandles => webDriver.WindowHandles;


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

        public bool AreElementsPresent(By by)
        {
            WaitForElementsVisible(by);
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

        //Работа с одним элементом используя Support Package
        public void WaitForIsVisibleExtra(By by)
        {
            var wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, 05));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
        }

        //Попытка работы с элементами используя SupportPackage
        public void WaitForElementsVisible(By by)
        {
            var wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, 05));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(by));
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
            _currentInstance = null;
            webDriver = null;
            _browser = null;
        }

        public ITargetLocator SwitchTo()
        {
            return webDriver.SwitchTo();
        }

        public void JsClick(IWebElement element) //webDriver changed to GetDriver
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)GetDriver();
            executor.ExecuteScript("arguments[0].click()", element);
        }

        public void JsHighlight(IWebElement element) //webDriver changed to GetDriver
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)GetDriver();
            executor.ExecuteScript("arguments[0].style.border='3px solid red'", element);
        }

        public static IWebDriver GetDriver()
        {
            return webDriver;
        }

    }
}
