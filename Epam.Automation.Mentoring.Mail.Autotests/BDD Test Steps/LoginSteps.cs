using Epam.Automation.Mentoring.Mail.Autotests.Entities;
using Epam.Automation.Mentoring.Mail.Autotests.Tests;
using Epam.Automation.Mentoring.Mail.Autotests.WebObjects;
using TechTalk.SpecFlow;

namespace Epam.Automation.Mentoring.Mail.Autotests
{
    [Binding]
    public class LoginSteps : BaseTest
    {
        [Given(@"I have navigated to the home page")]
        public void GivenIHaveNavigatedToTheHomePage()
        {
           // ScenarioContext.Current.Pending();
        }
        
        [Given(@"I have entered the email and password")]
        public void GivenIHaveEnteredTheEmailAndPassword()
        {
            var login = "tst_atmp_2020q2";
            var password = "Administratum4199";
            var user = new User(login, password);
            //Логинимся
            MailHomePage home = new MailHomePage(driver);
            home.Login(user);
            //ScenarioContext.Current.Pending();
        }
        
        [When(@"I press submit")]
        public void WhenIPressSubmit()
        {
            //ScenarioContext.Current.Pending();
        }
        
        [Then(@"I should be logged in")]
        public void ThenIShouldBeLoggedIn()
        {
            MailHomePage home = new MailHomePage(driver);
            home.ExitEmail();
            //ScenarioContext.Current.Pending();
        }
    }
}
