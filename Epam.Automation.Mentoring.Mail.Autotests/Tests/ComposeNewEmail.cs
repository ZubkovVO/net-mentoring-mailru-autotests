﻿using Epam.Automation.Mentoring.Mail.Autotests.WebDriver;
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
            TestDataProvider.FetchFromXmlReader();
        }

        [Fact]
        public void Compose_New_Email()
        {
            //Объявляем переменные, которые могут понадобится
            string addressee = TestDataProvider.addressee;
            string email = TestDataProvider.email;
            string password = TestDataProvider.password;
            string topic = TestDataProvider.topic;
            string text = TestDataProvider.text;



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