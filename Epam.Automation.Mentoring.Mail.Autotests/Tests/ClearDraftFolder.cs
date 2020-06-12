using Epam.Automation.Mentoring.Mail.Autotests.UIElements;
using Epam.Automation.Mentoring.Mail.Autotests.WebObjects;
using Xunit;

namespace Epam.Automation.Mentoring.Mail.Autotests.Tests
{
    public class ClearDraftFolder : BaseTest
    {

        public ClearDraftFolder() : base()
        {

        }

        [Fact]
        public void If_Present_Delete_Emails_From_Draft()
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
            EmailsContainer emails = menu.GoToDrafts();
                        
            //Добавлена реализация с использованием SupportPackage (все равно не работает)
            if (emails.FolderIsEmptyBool())
            {
                home.ExitEmail();
            }
            else
            {
                FolderMenu folderMenu = emails.GoToFolderMenu();
                folderMenu.SelectAll();
                folderMenu.Delete();
                Assert.True(emails.FolderIsEmpty());
                home.ExitEmail();
            }

        }             

    }
}
