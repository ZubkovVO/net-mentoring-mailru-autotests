using Epam.Automation.Mentoring.Mail.Autotests.WebDriver;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Epam.Automation.Mentoring.Mail.Autotests.WebObjects
{
    class EmailsContainer
    {
        private MyWebDriver driver;
        private string addressee;
        private string topic;

        public EmailsContainer(MyWebDriver driver)
        {
            //Объявляем переменные, которые могут понадобится
            XmlReader xml = new XmlReader();
            List<string> testDataArray = xml.XmlXpath();
            this.addressee = testDataArray[0];
            this.topic = testDataArray[3];

            this.driver = driver;
        }

        public IWebElement EmailAndTopicToValidate
        {
            get { return this.driver.FindElement(By.XPath("//div[@class='dataset-letters']//span[@title='" + addressee + "']" +
"/parent::div/following-sibling::div[contains(@class, 'llc__item_title')]//span[text()='" + topic + "']")); }
        }

        public ReadOnlyCollection<IWebElement> EmailAndTopicToValidateCol
        {
            get { return this.driver.FindElements(By.XPath("//div[@class='dataset-letters']//span[@title='" + addressee + "']" +
"/parent::div/following-sibling::div[contains(@class, 'llc__item_title')]//span[text()='" + topic + "']")); }
        }

        public DraftEmail OpenDraft()
        {
            EmailAndTopicToValidate.Click();
            return new DraftEmail(driver);
        }

        public bool ValidateAddresseeAndTopic()
        {
            return EmailAndTopicToValidateCol.Count > 0;
        }

        public void WaitForEmailSent()
        {
            driver.WaitForElementToDisappier(By.XPath("//div[@class='dataset-letters']//span[@title='" + addressee + "']" +
"/parent::div/following-sibling::div[contains(@class, 'llc__item_title')]//span[text()='" + topic + "']"));
        }
    }
}
