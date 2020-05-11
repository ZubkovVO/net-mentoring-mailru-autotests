using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Text;

namespace Epam.Automation.Mentoring.Mail.Autotests.WebObjects
{
    class BaseElement : IWebElement
    {
        private IWebDriver _driver = Browser.GetDriver();
        protected string _name;
        protected By _locator;
        protected IWebElement _element;

        public BaseElement(By locator, string name)
        {
            _locator = locator;
            _name = name == "" ? GetText() : name;
        }

        public BaseElement(By locator)
        {
            _locator = locator;
        }

        public string GetText()
        {
            WaitForIsVisible();
            return _element.Text;
        }

        public IWebElement GetElement()
        {
            try
            {
                _element = Browser.GetDriver().FindElement(_locator);
            }
            catch(Exception)
            {
                throw;
            }
            return _element;
        }

        public void WaitForIsVisible()
        {
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 30));
            var element = wait.Until(condition =>
            {
                try
                {
                    var elementToBeDisplayed = _driver.FindElement(_locator);
                    return elementToBeDisplayed;
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

        public string TagName => throw new NotImplementedException();

        public string Text => throw new NotImplementedException();

        public bool Enabled => throw new NotImplementedException();

        public bool Selected => throw new NotImplementedException();

        public Point Location => throw new NotImplementedException();

        public Size Size => throw new NotImplementedException();

        public bool Displayed => throw new NotImplementedException();

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void Click()
        {
            WaitForIsVisible();
            Browser.GetDriver().FindElement(_locator).Click();
        }

        public void JsClick() //Клик по API, использовать часто не рекомендуется, можно незаметить UX ошибки
        {
            WaitForIsVisible();
            IJavaScriptExecutor executor = (IJavaScriptExecutor)Browser.GetDriver();
            executor.ExecuteScript("arguments[0].click();", GetElement());
        }

        public IWebElement FindElement(By by)
        {
            throw new NotImplementedException();
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            throw new NotImplementedException();
        }

        public string GetAttribute(string attributeName)
        {
            throw new NotImplementedException();
        }

        public string GetCssValue(string propertyName)
        {
            throw new NotImplementedException();
        }

        public string GetProperty(string propertyName)
        {
            throw new NotImplementedException();
        }

        public void SendKeys(string text)
        {
            WaitForIsVisible();
            Browser.GetDriver().FindElement(_locator).SendKeys(text);
        }

        public void Submit()
        {
            throw new NotImplementedException();
        }
    }
}
