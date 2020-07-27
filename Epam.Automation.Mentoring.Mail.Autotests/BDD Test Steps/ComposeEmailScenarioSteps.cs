using Epam.Automation.Mentoring.Mail.Autotests.Entities;
using Epam.Automation.Mentoring.Mail.Autotests.WebDriver;
using Epam.Automation.Mentoring.Mail.Autotests.WebObjects;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using Xunit;

namespace Epam.Automation.Mentoring.Mail.Autotests.BDD_Test_Steps
{

    [Binding]
    public class ComposeEmailScenarioSteps
    {
        protected static MyWebDriver driver = MyWebDriver.Instance;

        public ComposeEmailScenarioSteps()
        {
            driver = MyWebDriver.Instance;
            TestDataProvider.FetchFromXmlReader();
        }

        Email email = new Email("nrco@mail.ru", "Just for test 121", "Something for testing purposes");

        [Given(@"I navigated to the home page")]
        public void GivenINavigatedToTheHomePage()
        {
            driver.Navigate().GoToUrl("https://www.mail.ru");
        }
        
        [Given(@"I logged in to email using ([aA-zZ0-9]+) and (\w+)")]
        public void GivenILoggedInToEmailUsingTst_Atmp_AndAdministratum(string p0, string p1)
        {
            User user = new User(p0, p1);
            MailHomePage home = new MailHomePage(driver);
            home.Login(user);
        }
        
        [Given(@"I have composed an email")]
        public void GivenIHaveComposedAnEmail()
        {
            MailMainMenu menu = new MailMainMenu(driver);
            MailComposeNewEmail newEmail = menu.ComposeNewEmail();
            newEmail.InputEmailData(email);
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
            Dispose();
        }

        private void Dispose()
        {
            Thread.Sleep(3000);
            driver.Quit();
        }
    }
}
