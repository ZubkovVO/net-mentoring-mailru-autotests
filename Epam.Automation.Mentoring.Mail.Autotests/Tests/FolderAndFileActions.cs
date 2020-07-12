using Epam.Automation.Mentoring.Mail.Autotests.PageObjects;
using Epam.Automation.Mentoring.Mail.Autotests.UIElements;
using Epam.Automation.Mentoring.Mail.Autotests.WebObjects;
using Xunit;

namespace Epam.Automation.Mentoring.Mail.Autotests.Tests
{
    public class FolderAndFileActions : BaseTest
    {

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
