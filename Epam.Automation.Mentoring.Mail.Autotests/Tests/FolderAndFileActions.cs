using Epam.Automation.Mentoring.Mail.Autotests.Entities;
using Epam.Automation.Mentoring.Mail.Autotests.PageObjects;
using Epam.Automation.Mentoring.Mail.Autotests.UIElements;
using Epam.Automation.Mentoring.Mail.Autotests.Utility;
using Epam.Automation.Mentoring.Mail.Autotests.WebObjects;
using Xunit;

namespace Epam.Automation.Mentoring.Mail.Autotests.Tests
{
    [Collection("Sequential")]
    public class FolderAndFileActions : BaseTest
    {
        public FolderAndFileActions()
        {
            TestDataProvider.FetchFromXmlReader();
        }

        [Fact]
        public void Create_Folder_And_Put_File_Inside()
        {
            //Объявляем переменные, которые могут понадобится
            var user = new User(TestDataProvider.Email, TestDataProvider.Password);

            //Логинимся
            MailHomePage home = new MailHomePage(driver);
            home.Login(user);

            //Переходим к меню и передаем инстанс драйвера дальше
            MailMainMenu menu = home.GoToMenu();
            CloudMainMenu cMenu = menu.GoToCloud();
            FilesContainer file = cMenu.ContentLoaded();

            //Работаем внутри блока с файлами, вызываем контекстное меню и создаем папку
            file.ContextClick();
            file.CtxCreate();
            file.CtxCreateFolder();
            file.InputFolderNameAndAccept();
            //Возвращаемся на главную, после создания папки
            cMenu.GoToHome();
            //Перетаскиваем файл в папку
            file.MoveFileToFolder();
            file.AcceptMoving();
        }
    }
}
