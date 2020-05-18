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
            GetDataFromXml xml = new GetDataFromXml();
            List<string> testDataArray = xml.XmlXpath();
            string addressee = testDataArray[0];
            string email = testDataArray[1];
            string password = testDataArray[2];
            string topic = testDataArray[3];
            string text = testDataArray[4];

            //Логинимся
            MailHomePage home = new MailHomePage(driver);
            home.goToPage();
            home.enterLogin(email);
            home.clickSubmitButton();
            home.enterPassword(password);

            MailMainMenu menu = home.goToMenu();

            //Приступаем к созданию нового письма
            MailComposeNewEmail newEmail = menu.composeNewEmail();
            newEmail.fillAddressee(addressee);
            newEmail.fillTopic(topic);
            newEmail.fillText(text);
            newEmail.clickSaveButton();
            newEmail.clickCloseButton();

            //Переходим в черновики
            EmailsContainer emails = menu.goToDrafts();

            //Открываем нужный черновик
            DraftEmail draft = emails.openDraft();
            Assert.True(draft.checkAddressee());
            Assert.True(draft.checkTopic());
            Assert.True(draft.checkText());
            draft.clickSendButton();
            draft.closeEmail();
            emails.waitForEmailSent();

            //Переходим в отправленные
            menu.goToSent();
            Assert.True(emails.validateAddresseeAndTopic());

            //Выходим из почты
            home.exitEmail();

        }

        public void Dispose()
        {
            Thread.Sleep(3000);
            driver.Close();
        }
    }
}
