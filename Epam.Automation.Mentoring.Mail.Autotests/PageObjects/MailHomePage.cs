using Epam.Automation.Mentoring.Mail.Autotests.WebDriver;
using OpenQA.Selenium;

namespace Epam.Automation.Mentoring.Mail.Autotests.WebObjects
{
    public class MailHomePage
    {
        private readonly MyWebDriver driver;

        public MailHomePage(MyWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement LoginField
        {
            get { return this.driver.FindElement(By.Id("mailbox:login")); }
        }

        public IWebElement SubmitButton
        {
            get { return this.driver.FindElement(By.Id("mailbox:submit")); }
        }

        public IWebElement PasswordField
        {
            get { return this.driver.FindElement(By.Id("mailbox:password")); }
        }

        public IWebElement Exit
        {
            get { return this.driver.FindElement(By.XPath(".//a[@title='выход']")); }
        }

        public MailMainMenu GoToMenu()
        {
            return new MailMainMenu(driver);
        }

        public void ExitEmail()
        {
            Exit.Click();
        }

        public void Login(string loginInput, string passwordInput)
        {
            driver.Navigate().GoToUrl("https://www.mail.ru");
            LoginField.SendKeys(loginInput);
            SubmitButton.Click();
            PasswordField.SendKeys(passwordInput);
            SubmitButton.Click();
        }
    }
}
