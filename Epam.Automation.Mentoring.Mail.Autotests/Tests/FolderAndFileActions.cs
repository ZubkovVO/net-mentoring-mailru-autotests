using Epam.Automation.Mentoring.Mail.Autotests.PageObjects;
using Epam.Automation.Mentoring.Mail.Autotests.UIElements;
using Epam.Automation.Mentoring.Mail.Autotests.WebObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Epam.Automation.Mentoring.Mail.Autotests.Tests
{
    public class FolderAndFileActions : BaseTest
    {
        public FolderAndFileActions() : base()
        {

        }

        [Fact]
        public void Create_Folder_And_Put_File_Inside()
        {
            //Объявляем переменные, которые могут понадобится
            string email = TestDataProvider.Email;
            string password = TestDataProvider.Password;

            //Логинимся
            MailHomePage home = new MailHomePage(driver);
            home.Login(email, password);

            //Переходим к меню и передаем инстанс драйвера дальше
            MailMainMenu menu = home.GoToMenu();

            CloudMainMenu cMenu = menu.GoToCloud();

            FilesContainer file = cMenu.ContentLoaded();

        }
    }
}
