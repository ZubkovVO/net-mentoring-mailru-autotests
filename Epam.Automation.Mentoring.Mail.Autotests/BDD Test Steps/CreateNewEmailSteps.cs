using Epam.Automation.Mentoring.Mail.Autotests.Entities;
using Epam.Automation.Mentoring.Mail.Autotests.Tests;
using Epam.Automation.Mentoring.Mail.Autotests.WebObjects;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace Epam.Automation.Mentoring.Mail.Autotests
{
    [Binding]
    public class CreateNewEmailSteps : BaseTest
    {
        public CreateNewEmailSteps()
        {
            TestDataProvider.FetchFromXmlReader();
        }

        User user = new User("tst_atmp_2020q2", "Administratum4199");
            Email email = new Email("nrco@mail.ru", "Just for test 121", "Something for testing purposes");

        [Given(@"I logged in to my email address")]
        public void GivenILoggedInToMyEmailAddress()
        {
            MailHomePage home = new MailHomePage(driver);
            home.Login(user);

        }

        [Given(@"I have composed an email")]
        public void GivenIHaveComposedAnEmail()
        {
            MailMainMenu menu = new MailMainMenu(driver);
            MailComposeNewEmail newEmail = menu.ComposeNewEmail();
            newEmail.InputEmailData(email);
        }

        [Given(@"I saved the email")]
        public void GivenISavedTheEmail()
        {
            MailComposeNewEmail newEmail = new MailComposeNewEmail(driver);
            newEmail.ClickSaveButton();
            newEmail.ClickCloseButton();
        }

        [When(@"I send it from drafts")]
        public void WhenISendItFromDrafts()
        {
            //Переходим в черновики
            MailMainMenu menu = new MailMainMenu(driver);
            EmailsContainer emails = menu.GoToDrafts();

            //Открываем нужный черновик
            DraftEmail draft = emails.OpenDraft();
            Assert.True(draft.CheckAddressee());
            Assert.True(draft.CheckTopic());
            Assert.True(draft.CheckText());
            draft.ClickSendButton();
            draft.CloseEmail();
            emails.WaitForEmailSent();
        }

        [Then(@"It should be sent")]
        public void ThenItShouldBeSent()
        {
            MailMainMenu menu = new MailMainMenu(driver);
            EmailsContainer emails = new EmailsContainer(driver);

            menu.GoToSent();
            Assert.True(emails.ValidateAddresseeAndTopic());

            MailHomePage home = new MailHomePage(driver);
            //Выходим из почты
            home.ExitEmail();
        }
    }
}
