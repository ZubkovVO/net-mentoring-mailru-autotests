using Epam.Automation.Mentoring.Mail.Autotests.UIElements;
using Epam.Automation.Mentoring.Mail.Autotests.WebDriver;
using Epam.Automation.Mentoring.Mail.Autotests.WebObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epam.Automation.Mentoring.Mail.Autotests.PageObjects
{
    public class CloudMainMenu : BasePage
    {
        public CloudMainMenu(MyWebDriver driver) : base(driver)
        {

        }

        public IWebElement Content
        {
            get { return this.driver.FindElement(By.XPath(".//div[@id = 'content']")); }
        }

        public FilesContainer ContentLoaded()
        {
            Content.Click();
            return new FilesContainer(driver);
        }


    }
}
