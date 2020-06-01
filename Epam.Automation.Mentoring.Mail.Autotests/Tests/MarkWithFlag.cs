using Epam.Automation.Mentoring.Mail.Autotests.UIElements;
using Epam.Automation.Mentoring.Mail.Autotests.WebDriver;
using Epam.Automation.Mentoring.Mail.Autotests.WebObjects;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace Epam.Automation.Mentoring.Mail.Autotests.Tests
{
    public class MarkWithFlag : BaseTest
    {

            public MarkWithFlag() : base()
            {

            }

        [Fact]
        public void Mark_Email_With_Flag()
        {
            //Объявляем переменные, которые могут понадобится
            string email = TestDataProvider.Email;
            string password = TestDataProvider.Password;

            //Логинимся
            MailHomePage home = new MailHomePage(driver);
            home.Login(email, password);

            //Переходим к меню и передаем инстанс драйвера дальше
            MailMainMenu menu = home.GoToMenu();

            //Переходим в черновики и в зависимости от того, есть письма или нет выходим или удаляем письма          
            EmailsContainer emails = menu.GoToSent();
            Assert.True(menu.AreWeOnSentFolder());
            emails.SelectEmail();
            Assert.True(emails.IsCheckboxChecked());

            FolderMenu folderMenu = emails.GoToFolderMenu();
            folderMenu.ClickMore();
            folderMenu.MarkWithFlag();
            Assert.True(emails.IsFlagOn());

        }

    }
}
