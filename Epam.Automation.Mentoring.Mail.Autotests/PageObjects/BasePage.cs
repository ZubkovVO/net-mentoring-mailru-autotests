using Epam.Automation.Mentoring.Mail.Autotests.WebDriver;
using System;
using System.Collections.Generic;
using System.Text;

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
