using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epam.Automation.Mentoring.Mail.Autotests.WebObjects
{
    class HomePage : BasePage
    {
        private static readonly By HomeLbl = By.ClassName("b-titles-outer"); //!!!поправить на свою реализацию

        public HomePage() : base(HomeLbl, "Home Page") { }

        //!!!поправить на свою реализацию
        private readonly BaseElement _peopleLink = new BaseElement(By.LinkText("https://people.onliner.by"));

        public void GoToPeopleSection()
        {
            _peopleLink.Click();
        }

        public void OneMoreMethod() { }
    }
}
