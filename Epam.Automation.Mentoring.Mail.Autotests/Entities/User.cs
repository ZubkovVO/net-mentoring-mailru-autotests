namespace Epam.Automation.Mentoring.Mail.Autotests.Entities
{
    public class User
    {
        public string Login { get; private set; }
        public string Password { get; private set; }

        public User(string _login, string _password)
        {
            Login = _login;
            Password = _password;
        }
    }
}
