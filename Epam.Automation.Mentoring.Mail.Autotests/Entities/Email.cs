using System;
using System.Collections.Generic;
using System.Text;

namespace Epam.Automation.Mentoring.Mail.Autotests.Entities
{
    public class Email
    {
        private readonly string _addressee;
        private readonly string _topic;
        private readonly string _text;

        public string[] EmailData { get; private set; }

        public Email(string addressee, string topic, string text)
        {
            this._addressee = addressee;
            this._topic = topic;
            this._text = text;

            EmailData = new[] { this._addressee, this._topic, this._text };
        }
    }
}
