using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Epam.Automation.Mentoring.Mail.Autotests.WebDriver
{
	public class Configuration
	{
		public static string GetEnviromentVar(string var, string defaultValue)
		{
			return ConfigurationManager.AppSettings[var] ?? defaultValue; //что это??
		}

		public static string Browser => GetEnviromentVar("Browser", "Chrome");

	}
}