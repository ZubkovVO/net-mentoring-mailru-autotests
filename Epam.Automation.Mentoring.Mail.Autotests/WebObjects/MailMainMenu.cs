using Epam.Automation.Mentoring.Mail.Autotests.WebDriver;
using OpenQA.Selenium;

namespace Epam.Automation.Mentoring.Mail.Autotests.WebObjects
{
    class MailMainMenu
    {
        private MyWebDriver driver;

        public MailMainMenu(MyWebDriver driver)
        {
            this.driver = driver;
        }


        public IWebElement compose
        {
            get { return this.driver.FindElement(By.XPath(".//span[@class='compose-button__wrapper']")); }
        }

        public IWebElement drafts
        {
            get { return this.driver.FindElement(By.XPath(".//div[@class='nav-folders']//a[@href='/drafts/']")); }
        }

        public IWebElement sent
        {
            get { return this.driver.FindElement(By.XPath(".//div[@class='nav-folders']//a[@href='/sent/']")); }
        }    

        public MailComposeNewEmail composeNewEmail()
        {
            compose.Click();
            return new MailComposeNewEmail(driver);
        }

        public EmailsContainer goToDrafts()
        {
            drafts.Click();
            return new EmailsContainer(driver);
        }

        public EmailsContainer goToSent()
        {
            sent.Click();
            return new EmailsContainer(driver);
        }

    }
}
