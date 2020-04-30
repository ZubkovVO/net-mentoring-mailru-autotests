using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xunit;

namespace Epam.Automation.Mentoring.Mail.Autotests
{
    class CustomWaits
    {
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


     /*  public static Func<IWebDriver, IWebElement> CheckIfAbsent(IWebDriver driver, By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            wait.Until<IWebElement>(driver) =>
             {
                try
                {
                    var element = driver.FindElement(by);
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

        }*/


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


