using Epam.Automation.Mentoring.Mail.Autotests.Entities;
using Epam.Automation.Mentoring.Mail.Autotests.Utility;
using Epam.Automation.Mentoring.Mail.Autotests.WebObjects;
using Xunit;

namespace Epam.Automation.Mentoring.Mail.Autotests.Tests
{
    [Collection("Sequential")]
    public class ComposeNewEmail : BaseTest
    {
        //SomeFixture fixture;
        public ComposeNewEmail()
        {
            TestDataProvider.FetchFromXmlReader();
        }

        [Theory]
        [JsonFileData("JsonData.json", "FullData")]
        public void Compose_New_Email(string login, string password, string addressee, string topic, string text)
        {
            testVar = new MethodNameIdentifier().TraceMessage();

            UITest(() =>
            {

                //Объявляем бизнес объекты и передаем в них значения из json
                var user = new User(login, password);
                var email = new Email(addressee, topic, text);

                //Логинимся
                MailHomePage home = new MailHomePage(driver);
                home.Login(user);

                //Переходим к меню и передаем инстанс драйвера дальше
                MailMainMenu menu = home.GoToMenu();

                //Приступаем к созданию нового письма
                MailComposeNewEmail newEmail = menu.ComposeNewEmail();
                newEmail.InputEmailData(email);
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

            });



        }
    }
}
