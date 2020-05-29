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
    public class ClearDraftFolder : IDisposable
    {

        private readonly MyWebDriver driver;

        public ClearDraftFolder()
        {
            driver = new MyWebDriver(new ChromeDriver());
            TestDataProvider.FetchFromXmlReader();
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
                        
            if (emails.FolderIsEmptyM())
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
               

        public void Dispose()
        {
            Thread.Sleep(3000);
            driver.Close();
        }
    }
}
