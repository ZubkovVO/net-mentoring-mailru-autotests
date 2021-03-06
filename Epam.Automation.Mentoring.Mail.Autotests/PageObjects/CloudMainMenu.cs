﻿using Epam.Automation.Mentoring.Mail.Autotests.UIElements;
using Epam.Automation.Mentoring.Mail.Autotests.WebDriver;
using OpenQA.Selenium;

namespace Epam.Automation.Mentoring.Mail.Autotests.PageObjects
{
    public class CloudMainMenu : BasePage
    {
        public CloudMainMenu(MyWebDriver driver) : base(driver) { }

        public IWebElement Content
        {
            get { return this.driver.FindElement(By.XPath(".//div[@id = 'content']")); }
        }

        public IWebElement Home
        {
            get { return this.driver.FindElement(By.XPath("//a[@href = '/home/' and @data-name='Облако']//span[text()='Облако']")); }
        }

        public FilesContainer ContentLoaded()
        {
            Content.Click();
            return new FilesContainer(driver);
        }

        public void GoToHome()
        {
            try
            {
                Home.Click();
            }
            catch (StaleElementReferenceException)
            {
                IWebElement cloud = driver.FindElement(By.XPath("//a[@href = '/home/']"));
                cloud.Click();
                cloud.Click(); //refactor later
            }
        }
    }
}
