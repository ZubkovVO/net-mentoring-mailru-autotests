using Epam.Automation.Mentoring.Mail.Autotests.WebDriver;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Epam.Automation.Mentoring.Mail.Autotests.WebObjects
{
    class DraftEmail
    {
        private MyWebDriver driver;
        private string addressee;
        private string topic;
        private string text;

        public DraftEmail(MyWebDriver driver)
        {
            //Объявляем переменные, которые могут понадобится
            GetDataFromXml xml = new GetDataFromXml();
            List<string> testDataArray = xml.XmlXpath();
            this.addressee = testDataArray[0];
            this.topic = testDataArray[3];
            this.text = testDataArray[4];

            this.driver = driver;
        }

        public ReadOnlyCollection<IWebElement> draftTopic
        {
            get { return this.driver.FindElements(By.XPath(".//input[@name='Subject' and @value='" + topic + "']")); }
        }

        public IWebElement findTopic
        {
            get { return this.driver.FindElement(By.XPath(".//input[@name='Subject' and @value='" + topic + "']")); }
        }

        public ReadOnlyCollection<IWebElement> draftText
        {
            get { return this.driver.FindElements(By.XPath(".//div[@role='textbox']//div[text()='" + text + "']")); }
        }

        public ReadOnlyCollection<IWebElement> draftAddressee
        {
            get { return this.driver.FindElements(By.XPath(".//div[@data-name='to']//div[@title='" + addressee + "']")); }
        }

        public IWebElement sendButton
        {
            get { return this.driver.FindElement(By.XPath(".//span[@title='Отправить']")); }
        }

        public IWebElement closeButton
        {
            get { return this.driver.FindElement(By.XPath(".//span[@title='Закрыть']")); }
        }

        public void findTopicAndClick()
        {
            findTopic.Click();
        }
        public bool checkTopic()
        {
            return draftTopic.Count > 0;          
        }

        public bool checkText()
        {
            
            return draftText.Count > 0;
        }

        public bool checkAddressee()
        {
            return draftAddressee.Count > 0;
        }

        public void clickSendButton()
        {
            sendButton.Click();
        }

        public EmailsContainer closeEmail()
        {
            closeButton.Click();
            return new EmailsContainer(driver);
        }
    }
}
