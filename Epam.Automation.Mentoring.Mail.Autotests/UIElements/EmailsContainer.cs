using Epam.Automation.Mentoring.Mail.Autotests.UIElements;
using Epam.Automation.Mentoring.Mail.Autotests.WebDriver;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace Epam.Automation.Mentoring.Mail.Autotests.WebObjects
{
    public class EmailsContainer
    {
        private readonly MyWebDriver driver;
        private readonly string addressee;
        private readonly string topic;

        public EmailsContainer(MyWebDriver driver)
        {
            //Объявляем переменные, которые могут понадобится
            this.addressee = TestDataProvider.Addressee;
            this.topic = TestDataProvider.Topic;

            this.driver = driver;
        }

        public IWebElement EmailAndTopicToValidate
        {
            get { return this.driver.FindElement(By.XPath("//div[@class='dataset-letters']//span[@title='" + addressee + "']" +
"/parent::div/following-sibling::div[contains(@class, 'llc__item_title')]//span[text()='" + topic + "']")); }
        }

        public bool EmailAndTopicToValidateCol
        {
            get { return this.driver.IsElementPresent(By.XPath("//div[@class='dataset-letters']//span[@title='" + addressee + "']" +
"/parent::div/following-sibling::div[contains(@class, 'llc__item_title')]//span[text()='" + topic + "']")); }
        }

        public bool FolderIsEmptyText
        {
            get { return this.driver.IsElementPresent(By.XPath("//span[text()='У вас нет незаконченных']")); }
        }

        public ReadOnlyCollection<IWebElement> FolderIsEmptyTextM
        {
            get { return this.driver.FindElements(By.XPath("//span[text()='У вас нет незаконченных']")); }
        }

        public bool FolderIsEmptyTextBool
        {
            get { return this.driver.AreElementsPresent(By.XPath("//span[text()='У вас нет незаконченных']")); }
        }



        public IWebElement EmailCheckbox
        {
            get { return this.driver.FindElement(By.XPath(".//div[@class='dataset-letters']//div[@class='llc__avatar']")); }
        }

        public bool EmailCheckboxChecked
        {
            get { return this.driver.IsElementPresent(By.XPath(".//button[contains(@class,'ll-av_is-active')]")); }
        }

        public bool FlagOn
        {
            get { return this.driver.IsElementPresent(By.XPath("//button[@title='Снять флажок']")); }
        }             

        public bool IsFlagOn()
        {
            return FlagOn;
        }

        public void SelectEmail()
        {
            EmailCheckbox.Click();
        }

        public bool IsCheckboxChecked()
        {
            return EmailCheckboxChecked;            
        }

        public bool FolderIsEmpty()
        {
            return FolderIsEmptyText;
        }

        public bool FolderIsEmptyM()
        {
            return FolderIsEmptyTextM.Count > 0;
        }

        public bool FolderIsEmptyBool()
        {
            return FolderIsEmptyTextBool;
        }

        public DraftEmail OpenDraft()
        {
            EmailAndTopicToValidate.Click();
            return new DraftEmail(driver);
        }

        public FolderMenu GoToFolderMenu()
        {
            return new FolderMenu(driver);
        }

        public bool ValidateAddresseeAndTopic()
        {
            return EmailAndTopicToValidateCol;
        }

        public void WaitForEmailSent()
        {
            driver.WaitForElementToDisappier(By.XPath("//div[@class='dataset-letters']//span[@title='" + addressee + "']" +
"/parent::div/following-sibling::div[contains(@class, 'llc__item_title')]//span[text()='" + topic + "']"));
        }
    }
}
