using Epam.Automation.Mentoring.Mail.Autotests.Entities;
using Epam.Automation.Mentoring.Mail.Autotests.Utility;
using Epam.Automation.Mentoring.Mail.Autotests.WebDriver;
using Epam.Automation.Mentoring.Mail.Autotests.WebObjects;
using log4net;
using OpenQA.Selenium;
using System;
using System.IO;
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
            testVar = new MethodNameIdentifier().TraceMessage();

            UITest(() =>
            {
                var user = new User(login, password);

                //Логинимся
                MailHomePage home = new MailHomePage(driver);
                Logger.Log.Info("Loogging to email");
                home.Login(user);
                Logger.Log.Info("Login succesfull");

                //Выходим из почты
                Logger.Log.Info("Logging out");
                home.ExitEmail();
                Logger.Log.Info("Log out succesful");
            });


           /* var user = new User(login, password);

            //Логинимся
            MailHomePage home = new MailHomePage(driver);
            home.Login(user) ;

            //Выходим из почты
            home.ExitEmail();    */        
        }
    }
}
