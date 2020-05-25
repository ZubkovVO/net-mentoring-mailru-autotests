using Epam.Automation.Mentoring.Mail.Autotests.WebDriver;
using OpenQA.Selenium;

namespace Epam.Automation.Mentoring.Mail.Autotests.WebObjects
{
    public class MailMainMenu
    {
        private MyWebDriver driver;

        public MailMainMenu(MyWebDriver driver)
        {
            this.driver = driver;
        }


        public IWebElement Compose
        {
            get { return this.driver.FindElement(By.XPath(".//span[@class='compose-button__wrapper']")); }
        }

        public IWebElement Drafts
        {
            get { return this.driver.FindElement(By.XPath(".//div[@class='nav-folders']//a[@href='/drafts/']")); }
        }

        public IWebElement Sent
        {
            get { return this.driver.FindElement(By.XPath(".//div[@class='nav-folders']//a[@href='/sent/']")); }
        }    

        public MailComposeNewEmail ComposeNewEmail()
        {
            Compose.Click();
            return new MailComposeNewEmail(driver);
        }

        public EmailsContainer GoToDrafts()
        {
            Drafts.Click();
            return new EmailsContainer(driver);
        }

        public EmailsContainer GoToSent()
        {
            Sent.Click();
            return new EmailsContainer(driver);
        }

    }
}
