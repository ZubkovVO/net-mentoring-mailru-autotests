using Epam.Automation.Mentoring.Mail.Autotests.WebDriver;
using Epam.Automation.Mentoring.Mail.Autotests.WebObjects;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace Epam.Automation.Mentoring.Mail.Autotests.Tests
{
    public class ComposeNewEmail : IDisposable
    {        
        private MyWebDriver driver;

        public ComposeNewEmail()
        {
            driver = new MyWebDriver(new ChromeDriver());
        }

        [Fact]
        public void Compose_New_Email()
        {
            //Объявляем переменные, которые могут понадобится
            XmlReader xml = new XmlReader();
            List<string> testDataArray = xml.XmlXpath();
            string addressee = testDataArray[0];
            string email = testDataArray[1];
            string password = testDataArray[2];
            string topic = testDataArray[3];
            string text = testDataArray[4];

            //Логинимся
            MailHomePage home = new MailHomePage(driver);
            home.Login(email, password);

            //Переходим к меню и передаем инстанс драйвера дальше
            MailMainMenu menu = home.GoToMenu();

            //Приступаем к созданию нового письма
            MailComposeNewEmail newEmail = menu.ComposeNewEmail();
            newEmail.FillAddressee(addressee);
            newEmail.FillTopic(topic);
            newEmail.FillText(text);
            newEmail.ClickSaveButton();
            newEmail.ClickCloseButton();

            //Переходим в черновики
            EmailsContainer emails = menu.GoToDrafts();

            //Открываем нужный черновик
            DraftEmail draft = emails.OpenDraft();
            Assert.True(draft.CheckAddressee());
            Assert.True(draft.CheckTopic());
            Assert.True(draft.CheckText());
            draft.ClickSendButton();
            draft.CloseEmail();
            emails.WaitForEmailSent();

            //Переходим в отправленные
            menu.GoToSent();
            Assert.True(emails.ValidateAddresseeAndTopic());

            //Выходим из почты
            home.ExitEmail();

        }

        public void Dispose()
        {
            Thread.Sleep(3000);
            driver.Close();
        }
    }
}
