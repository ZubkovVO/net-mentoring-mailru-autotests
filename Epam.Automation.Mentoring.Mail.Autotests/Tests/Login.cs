using Epam.Automation.Mentoring.Mail.Autotests.Entities;
using Epam.Automation.Mentoring.Mail.Autotests.Utility;
using Epam.Automation.Mentoring.Mail.Autotests.WebObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Epam.Automation.Mentoring.Mail.Autotests.Tests
{
    public class Login : BaseTest
    {
        [Theory]
        [JsonFileData("JsonData.json","LoginData")]
        public void Login_to_Email(string login, string password)
        {
            var user = new User(login, password);

            //Логинимся
            MailHomePage home = new MailHomePage(driver);
            home.Login(user.UserData[0], user.UserData[1]);

            //Переходим к меню и передаем инстанс драйвера дальше
            MailMainMenu menu = home.GoToMenu();

            //Выходим из почты
            home.ExitEmail();

        }
    }

}
