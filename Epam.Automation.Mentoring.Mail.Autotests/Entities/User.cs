namespace Epam.Automation.Mentoring.Mail.Autotests.Entities
{
    public class User
    {
        public string login { get; private set; }
        public string password { get; private set; }

        public User(string _login, string _password)
        {
            login = _login;
            password = _password;
        }
    }
}
