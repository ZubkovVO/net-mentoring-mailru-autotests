using Epam.Automation.Mentoring.Mail.Autotests.Entities;
using Epam.Automation.Mentoring.Mail.Autotests.PageObjects;
using Epam.Automation.Mentoring.Mail.Autotests.Tests;
using Epam.Automation.Mentoring.Mail.Autotests.WebDriver;
using OpenQA.Selenium;

namespace Epam.Automation.Mentoring.Mail.Autotests.WebObjects
{
    public class MailHomePage : BasePage
    {

        public MailHomePage(MyWebDriver driver) : base(driver) { }

        public IWebElement LoginField
        {
            get { return driver.FindElement(By.Id("mailbox:login")); }
        }

        public IWebElement SubmitButton
        {
            get { return driver.FindElement(By.Id("mailbox:submit")); }
        }

        public IWebElement PasswordField
        {
            get { return driver.FindElement(By.Id("mailbox:password")); }
        }

        public IWebElement Exit
        {
            get { return driver.FindElement(By.XPath(".//a[@title='выход']")); }
        }

        public MailMainMenu GoToMenu()
        {
            return new MailMainMenu(driver);
        }

        public void ExitEmail()
        {
            Exit.Click();
        }

        public MailMainMenu Login(User user)
        {
            LoginField.SendKeys(user.Login);
            SubmitButton.Click();
            PasswordField.SendKeys(user.Password);
            SubmitButton.Click();
            return new MailMainMenu(driver);
        }
    }
}
