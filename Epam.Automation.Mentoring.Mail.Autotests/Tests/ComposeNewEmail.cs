using Epam.Automation.Mentoring.Mail.Autotests.WebObjects;
using Xunit;

namespace Epam.Automation.Mentoring.Mail.Autotests.Tests
{
    public class ComposeNewEmail : BaseTest
    {        

        public ComposeNewEmail() : base()
        {

        }

        [Fact]
        public void Compose_New_Email()
        {
            //Объявляем переменные, которые могут понадобится
            string addressee = TestDataProvider.Addressee;
            string email = TestDataProvider.Email;
            string password = TestDataProvider.Password;
            string topic = TestDataProvider.Topic;
            string text = TestDataProvider.Text;

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

    }
}
