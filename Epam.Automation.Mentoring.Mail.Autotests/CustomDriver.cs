using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xunit;

namespace Epam.Automation.Mentoring.Mail.Autotests
{
    class CustomDriver
    {
        //Метод передает значение в поле, при этом метод ждет пока поле будет доступно
        public void SendKeys(IWebDriver driver, By by, string valueToType)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement myElement = wait.Until<IWebElement>(driver =>
              {
                  IWebElement tempElement = driver.FindElement(by);
                  return (tempElement.Displayed && tempElement.Enabled) ? tempElement : null;
              }
              );
            myElement.Clear();
            myElement.SendKeys(valueToType);
        }

        //Метод передает операцию ПКМ, при этом ждет, что эелемент доступен
        public void Click(IWebDriver driver, By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement myElement = wait.Until<IWebElement>(driver =>
            {
                IWebElement tempElement = driver.FindElement(by);
                return (tempElement.Displayed && tempElement.Enabled) ? tempElement : null;
            }
              );
            myElement.Click();
            
        }

        //Метод проверяет, что элемент доступен
        public void CheckIfPresent(IWebDriver driver, By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement myElement = wait.Until<IWebElement>(driver =>
            {
                IWebElement tempElement = driver.FindElement(by);
                return (tempElement.Displayed && tempElement.Enabled) ? tempElement : null;
            }
            );

        }
       
       //Метод проверяет, что элемент недоступен/отсутствует на странице 
       public static Func<IWebDriver, bool> InvisibilityOfElementLocated(By locator)
         {
             return (driver) =>
             {
                 try
                 {
                     var element = driver.FindElement(locator);
                     return !element.Displayed;
                 }
                 catch (NoSuchElementException)
                 {
                     // Returns true because the element is not present in DOM. The
                     // try block checks if the element is present but is invisible.
                     return true;
                 }
                 catch (StaleElementReferenceException)
                 {
                     // Returns true because stale element reference implies that element
                     // is no longer visible.
                     return true;
                 }
             };
         }

    }

    }


