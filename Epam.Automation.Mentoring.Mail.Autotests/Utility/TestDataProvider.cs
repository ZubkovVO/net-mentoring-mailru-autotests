using System;
using System.Collections.Generic;
using System.Text;

namespace Epam.Automation.Mentoring.Mail.Autotests
{
    public static class TestDataProvider
    {
        public static string addressee { get; set; }
        public static string email { get; set; }
        public static string password { get; set; }
        public static string topic { get; set; }
        public static string text { get; set; }


        public static void FetchFromXmlReader()
        {
            XmlReader xml = new XmlReader();
            List<string> testDataArray = xml.XmlXpath();
            addressee = testDataArray[0];
            email = testDataArray[1];
            password = testDataArray[2];
            topic = testDataArray[3];
            text = testDataArray[4];
        }


    }
}
