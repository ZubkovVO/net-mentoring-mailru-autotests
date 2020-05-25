using System;
using System.Collections.Generic;
using System.Text;

namespace Epam.Automation.Mentoring.Mail.Autotests
{
    public static class TestDataProvider
    {
        public static string Addressee { get; set; }
        public static string Email { get; set; }
        public static string Password { get; set; }
        public static string Topic { get; set; }
        public static string Text { get; set; }


        public static void FetchFromXmlReader()
        {
            XmlReader xml = new XmlReader();
            List<string> testDataArray = xml.XmlXpath();
            Addressee = testDataArray[0];
            Email = testDataArray[1];
            Password = testDataArray[2];
            Topic = testDataArray[3];
            Text = testDataArray[4];
        }


    }
}
