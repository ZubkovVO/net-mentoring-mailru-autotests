using Epam.Automation.Mentoring.Mail.Autotests.WebDriver;
using OpenQA.Selenium;

namespace Epam.Automation.Mentoring.Mail.Autotests.WebObjects
{
    class MailHomePage
    {
        private MyWebDriver driver;

        public MailHomePage(MyWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement loginField
        {
            get { return this.driver.FindElement(By.Id("mailbox:login")); }
        }

        public IWebElement submitButton
        {
            get { return this.driver.FindElement(By.Id("mailbox:submit")); }
        }

        public IWebElement passwordField
        {
            get { return this.driver.FindElement(By.Id("mailbox:password")); }
        }

        public IWebElement exit
        {
            get { return this.driver.FindElement(By.XPath(".//a[@title='выход']")); }
        }

        public void goToPage()
        {
            driver.Navigate().GoToUrl("https://www.mail.ru");
        }

        public void enterLogin(string loginInput)
        {
            loginField.SendKeys(loginInput);
        }

        public void clickSubmitButton()
        {
            submitButton.Click();
        }

        public void enterPassword(string passwordInput)
        {
            passwordField.SendKeys(passwordInput);
        }

        public MailMainMenu goToMenu()
        {
            submitButton.Click();
            return new MailMainMenu(driver);
        }

        public void exitEmail()
        {
            exit.Click();
        }
    }
}
