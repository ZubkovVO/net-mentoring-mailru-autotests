namespace Epam.Automation.Mentoring.Mail.Autotests.Entities
{
    public class Email
    {
        public string Addressee { get; private set; }
        public string Topic { get; private set; }
        public string Text { get; private set; }

        public Email(string _addressee, string _topic, string _text)
        {
            Addressee = _addressee;
            Topic = _topic;
            Text = _text;

        }
    }
}
