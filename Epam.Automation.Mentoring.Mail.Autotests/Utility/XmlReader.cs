﻿using System.Collections.Generic;
using System.Xml.XPath;

namespace Epam.Automation.Mentoring.Mail.Autotests
{
    public class XmlReader
    {
        public List<string> XmlXpath()
        {
            // abs.path C:\\Users\\nrcos\\source\\repos\\Automated Testing Mentoring Program [2020Q2 RU]\\Epam.Automation.Mentoring.Mail.Autotests\\XmlData.xml
            XPathDocument document = new XPathDocument("..\\..\\..\\XmlData.xml");
            XPathNavigator navigator = document.CreateNavigator();
           
            //Ищем и добавляем в массив все необходимые занчения
            XPathNavigator addressee = navigator.SelectSingleNode("//addressee");
            XPathNavigator login = navigator.SelectSingleNode("//login");
            XPathNavigator password = navigator.SelectSingleNode("//password");
            XPathNavigator topic = navigator.SelectSingleNode("//topic");
            XPathNavigator emailText = navigator.SelectSingleNode("//emailtext");
            List<string> dataArray = new List<string>();
            dataArray.Add(addressee.Value); //0
            dataArray.Add(login.Value); //1
            dataArray.Add(password.Value); //2
            dataArray.Add(topic.Value); //3
            dataArray.Add(emailText.Value); //4
            return dataArray;
        }
    }
}
