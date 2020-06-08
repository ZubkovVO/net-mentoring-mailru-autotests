using Epam.Automation.Mentoring.Mail.Autotests.WebDriver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Epam.Automation.Mentoring.Mail.Autotests.UIElements
{
    public class FolderMenu
    {
        private readonly MyWebDriver driver;
        private readonly string addressee;
        private readonly string topic;

        public FolderMenu(MyWebDriver driver)
        {
            //Объявляем переменные, которые могут понадобится
            this.addressee = TestDataProvider.Addressee;
            this.topic = TestDataProvider.Topic;

            this.driver = driver;
        }

        public IWebElement SelectAllButton
        {
            get { return this.driver.FindElement(By.XPath(".//span[@title='Выделить все']")); }
        }

        public IWebElement DeleteButton
        {
            get { return this.driver.FindElement(By.XPath(".//span[@title='Удалить']")); }
        }

        public IWebElement MoreButton
        {
            get { return this.driver.FindElement(By.XPath(".//span[@title='Ещё']")); }
        }

        public IWebElement Flag
        {
            get { return this.driver.FindElement(By.XPath(".//div[@class='dropdown-actions']//span[text()='Пометить флажком']")); }
        }

        public void MarkWithFlag()
        {
            Flag.Click();
        }

        public void SelectAll()
        {
            SelectAllButton.Click();
        }

        public void ClickMore()
        {
            MoreButton.Click();
        }

        public void Delete()
        {
            DeleteButton.Click();
        }
    }
}
