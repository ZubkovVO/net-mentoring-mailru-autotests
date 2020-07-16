using Epam.Automation.Mentoring.Mail.Autotests.PageObjects;
using Epam.Automation.Mentoring.Mail.Autotests.WebDriver;
using OpenQA.Selenium;

namespace Epam.Automation.Mentoring.Mail.Autotests.WebObjects
{
    public class MailComposeNewEmail : BasePage
    {
        public MailComposeNewEmail(MyWebDriver driver) : base(driver) { }

        public IWebElement Addressee
        {
            get { return driver.FindElement(By.XPath(".//div[@data-name='to']//input[starts-with(@type, 'text')]")); }
        }

        public IWebElement Topic
        {
            get { return driver.FindElement(By.XPath(".//input[starts-with(@name, 'Subject')]")); }
        }

        public IWebElement MessageText
        {
            get { return driver.FindElement(By.XPath(".//div[@role='textbox']/div[1]")); }
        }

        public IWebElement SaveButton
        {
            get { return driver.FindElement(By.XPath(".//span[@title='Сохранить']")); }
        }

        public IWebElement CloseButton
        {
            get { return driver.FindElement(By.XPath(".//button[@title='Закрыть']")); }
        }

        public void FillAddressee(string to)
        {
            Addressee.SendKeys(to);
        }

        public void FillTopic(string topicInput)
        {
            Topic.SendKeys(topicInput);
        }

        public void FillText(string emailText)
        {
            MessageText.SendKeys(emailText);
        }

        public void ClickSaveButton()
        {
            SaveButton.Click();
        }

        public void ClickCloseButton()
        {
            CloseButton.Click();
        }

        public MailMainMenu GoToMenu()
        {
            return new MailMainMenu(driver);
        }

    }
}
