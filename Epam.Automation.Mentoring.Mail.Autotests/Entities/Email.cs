namespace Epam.Automation.Mentoring.Mail.Autotests.Entities
{
    public class Email
    {
        public string addressee { get; private set; }
        public string topic { get; private set; }
        public string text { get; private set; }

        public Email(string _addressee, string _topic, string _text)
        {
            addressee = _addressee;
            topic = _topic;
            text = _text;

        }
    }
}
