using Epam.Automation.Mentoring.Mail.Autotests.PageObjects;
using Epam.Automation.Mentoring.Mail.Autotests.WebDriver;
using OpenQA.Selenium;
using System.Linq;

namespace Epam.Automation.Mentoring.Mail.Autotests.WebObjects
{
    public class MailMainMenu : BasePage
    {

        public MailMainMenu(MyWebDriver driver) : base(driver) { }


        public IWebElement Compose
        {
            get { return driver.FindElement(By.XPath(".//span[@class='compose-button__wrapper']")); }
        }

        public IWebElement Drafts
        {
            get { return driver.FindElement(By.XPath(".//div[@class='nav-folders']//a[@href='/drafts/']")); }
        }

        public IWebElement Sent
        {
            get { return driver.FindElement(By.XPath(".//div[@class='nav-folders']//a[@href='/sent/']")); }
        }


        public bool SentIsCurrent
        {
            get { return driver.IsElementPresent(By.XPath("//a[contains(@class,'nav__item_active') and @href='/sent/']")); }
        }

        public IWebElement Cloud
        {
            get { return driver.FindElement(By.XPath(".//div[contains(@class,'sidebar')]//a[@href='https://cloud.mail.ru']")); }
        }

        public MailComposeNewEmail ComposeNewEmail()
        {
            Compose.Click();
            return new MailComposeNewEmail(driver);
        }

        public bool AreWeOnSentFolder()
        {
            return SentIsCurrent;
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

        public CloudMainMenu GoToCloud()
        {
            Cloud.Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            return new CloudMainMenu(driver);
        }

    }
}
