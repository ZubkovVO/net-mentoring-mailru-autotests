﻿using Epam.Automation.Mentoring.Mail.Autotests.Entities;
using Epam.Automation.Mentoring.Mail.Autotests.UIElements;
using Epam.Automation.Mentoring.Mail.Autotests.WebObjects;
using Xunit;

namespace Epam.Automation.Mentoring.Mail.Autotests.Tests
{
    [Collection("Sequential")]
    public class MarkWithFlag : BaseTest
    {

        public MarkWithFlag()
        {
            TestDataProvider.FetchFromXmlReader();
        }

        [Fact]
        public void Mark_Email_With_Flag()
        {
            //Объявляем переменные, которые могут понадобится
            var user = new User(TestDataProvider.Email, TestDataProvider.Password);

            //Логинимся
            MailHomePage home = new MailHomePage(driver);
            home.Login(user);

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
