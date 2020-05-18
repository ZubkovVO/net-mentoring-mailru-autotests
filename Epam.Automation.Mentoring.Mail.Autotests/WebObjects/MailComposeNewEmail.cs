using Epam.Automation.Mentoring.Mail.Autotests.WebDriver;
using OpenQA.Selenium;

namespace Epam.Automation.Mentoring.Mail.Autotests.WebObjects
{
    class MailComposeNewEmail
    {
        private MyWebDriver driver;

        public MailComposeNewEmail(MyWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement addressee
        {
            get { return this.driver.FindElement(By.XPath(".//div[@data-name='to']//input[starts-with(@type, 'text')]")); }
        }

        public IWebElement topic
        {
            get { return this.driver.FindElement(By.XPath(".//input[starts-with(@name, 'Subject')]")); }
        }

        public IWebElement messageText
        {
            get { return this.driver.FindElement(By.XPath(".//div[@role='textbox']/div[1]")); }
        }

        public IWebElement saveButton
        {
            get { return this.driver.FindElement(By.XPath(".//span[@title='Сохранить']")); }
        }

        public IWebElement closeButton
        {
            get { return this.driver.FindElement(By.XPath(".//button[@title='Закрыть']")); }
        }

        public void fillAddressee(string to)
        {
            addressee.SendKeys(to);
        }

        public void fillTopic(string topicInput)
        {
            topic.SendKeys(topicInput);
        }

        public void fillText(string emailText)
        {
            messageText.SendKeys(emailText);
        }

        public void clickSaveButton()
        {
            saveButton.Click();
        }

        public void clickCloseButton()
        {
            closeButton.Click();
        }

        public MailMainMenu goToMenu()
        {
            return new MailMainMenu(driver);
        }

    }
}
