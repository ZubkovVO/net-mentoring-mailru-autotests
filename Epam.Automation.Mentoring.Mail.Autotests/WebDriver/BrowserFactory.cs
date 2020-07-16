using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;


namespace Epam.Automation.Mentoring.Mail.Autotests.WebDriver
{
	public class BrowserFactory
	{
		public enum BrowserType
		{
			Chrome,
			Firefox,
			remoteFirefox,
			remoteChrome
		}

		public static IWebDriver GetDriver(BrowserType type)
		{
			IWebDriver driver = null;

			switch (type)
			{
				case BrowserType.Chrome:
					{				
						var options = new ChromeOptions();
						options.AddArguments("start-maximized");
						driver = new ChromeDriver(options);
						break;
					}
				case BrowserType.Firefox:
					{
						var options = new FirefoxOptions();
						driver = new FirefoxDriver(options);
						break;
					}
				case BrowserType.remoteFirefox:
					{
						var options = new FirefoxOptions();
						driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), options);
						break;
					}
				case BrowserType.remoteChrome:
					{
						var options = new ChromeOptions();
						options.AddArguments("start-maximized");
						driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), options);
						break;
					}
			}
			return driver;
		}
	}
}
