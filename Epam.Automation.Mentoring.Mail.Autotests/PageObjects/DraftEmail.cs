using Epam.Automation.Mentoring.Mail.Autotests.WebDriver;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Epam.Automation.Mentoring.Mail.Autotests.WebObjects
{
    public class DraftEmail
    {
        private readonly MyWebDriver driver;
        private readonly string addressee;
        private readonly string topic;
        private readonly string text;

        public DraftEmail(MyWebDriver driver)
        {
            //Объявляем переменные, которые могут понадобится
            this.addressee = TestDataProvider.Addressee;
            this.topic = TestDataProvider.Topic;
            this.text = TestDataProvider.Text;

            this.driver = driver;
        }

        public ReadOnlyCollection<IWebElement> DraftTopic
        {
            get { return this.driver.FindElements(By.XPath(".//input[@name='Subject' and @value='" + topic + "']")); }
        }

        public IWebElement FindTopic
        {
            get { return this.driver.FindElement(By.XPath(".//input[@name='Subject' and @value='" + topic + "']")); }
        }

        public ReadOnlyCollection<IWebElement> DraftText
        {
            get { return this.driver.FindElements(By.XPath(".//div[@role='textbox']//div[text()='" + text + "']")); }
        }

        public ReadOnlyCollection<IWebElement> DraftAddressee
        {
            get { return this.driver.FindElements(By.XPath(".//div[@data-name='to']//div[@title='" + addressee + "']")); }
        }

        public IWebElement SendButton
        {
            get { return this.driver.FindElement(By.XPath(".//span[@title='Отправить']")); }
        }

        public IWebElement CloseButton
        {
            get { return this.driver.FindElement(By.XPath(".//span[@title='Закрыть']")); }
        }

        public void FindTopicAndClick()
        {
            FindTopic.Click();
        }
        public bool CheckTopic()
        {
            return DraftTopic.Count > 0;          
        }

        public bool CheckText()
        {
            
            return DraftText.Count > 0;
        }

        public bool CheckAddressee()
        {
            return DraftAddressee.Count > 0;
        }

        public void ClickSendButton()
        {
            SendButton.Click();
        }

        public EmailsContainer CloseEmail()
        {
            CloseButton.Click();
            return new EmailsContainer(driver);
        }
    }
}
