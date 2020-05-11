using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epam.Automation.Mentoring.Mail.Autotests.WebObjects
{
    class BasePage
    {
        protected By _titleLocator;
        protected string _title;
        public static string _titleForm;

        protected BasePage(By TitleLocator, string title)
        {
            _titleLocator = TitleLocator;
            _title = _titleForm = title;
            AssertIsOpen();

        }

        private void AssertIsOpen()
        {
            var label = new BaseElement(_titleLocator, _title);
            label.WaitForIsVisible();
        }
    }
}
