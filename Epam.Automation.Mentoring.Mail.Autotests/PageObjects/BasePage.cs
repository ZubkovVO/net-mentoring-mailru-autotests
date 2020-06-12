using Epam.Automation.Mentoring.Mail.Autotests.WebDriver;

namespace Epam.Automation.Mentoring.Mail.Autotests.PageObjects
{
    public abstract class BasePage
    {
        protected MyWebDriver driver;

        public BasePage(MyWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
