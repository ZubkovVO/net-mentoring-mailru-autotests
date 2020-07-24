using Epam.Automation.Mentoring.Mail.Autotests.Entities;
using Epam.Automation.Mentoring.Mail.Autotests.UIElements;
using Epam.Automation.Mentoring.Mail.Autotests.Utility;
using Epam.Automation.Mentoring.Mail.Autotests.WebObjects;
using System;
using Xunit;

namespace Epam.Automation.Mentoring.Mail.Autotests.Tests
{
    [Collection("Sequential")]
    public class ClearDraftFolder : BaseTest
    {

        public ClearDraftFolder()
        {
            TestDataProvider.FetchFromXmlReader();
        }

        [Fact]
        public void If_Present_Delete_Emails_From_Draft()
        {

            testVar = new MethodNameIdentifier().TraceMessage();

            UITest(() =>
            {

                //Объявляем переменные, которые могут понадобится
                var user = new User(TestDataProvider.Email, TestDataProvider.Password);

                //Логинимся
                MailHomePage home = new MailHomePage(driver);
                home.Login(user);

                //Переходим к меню и передаем инстанс драйвера дальше
                MailMainMenu menu = home.GoToMenu();

                //Переходим в черновики и в зависимости от того, есть письма или нет выходим или удаляем письма          
                EmailsContainer emails = menu.GoToDrafts();

                //Добавлена реализация с использованием SupportPackage (все равно не работает)
                if (emails.FolderIsEmptyBool())
                {
                    Logger.Log.Debug("The results for if path" + emails.FolderIsEmptyBool());
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


            });


           

        }             

    }
}
