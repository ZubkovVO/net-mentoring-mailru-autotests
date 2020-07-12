using System;
using System.Collections.Generic;
using System.Text;

namespace Epam.Automation.Mentoring.Mail.Autotests.Entities
{
    public class User
    {
        private readonly string _login;
        private readonly string _password;

        public string[] UserData { get; private set; } 

        public User(string login, string password)
        {
            this._login = login;
            this._password = password;

            UserData = new[] { this._login, this._password };
        }
    }
}
