using Epam.Automation.Mentoring.Mail.Autotests.Entities;
using Epam.Automation.Mentoring.Mail.Autotests.Utility;
using Epam.Automation.Mentoring.Mail.Autotests.WebObjects;
using Xunit;

namespace Epam.Automation.Mentoring.Mail.Autotests.Tests
{
    [Collection("Sequential")]
    public class Login : BaseTest
    {
        [Theory]
        [JsonFileData("JsonData.json","LoginData")]
        public void Login_to_Email(string login, string password)
        {
            var user = new User(login, password);

            //Логинимся
            MailHomePage home = new MailHomePage(driver);
            home.Login(user) ;

            //Выходим из почты
            home.ExitEmail();
        }
    }
}
