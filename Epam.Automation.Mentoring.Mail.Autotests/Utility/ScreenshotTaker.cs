using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using Epam.Automation.Mentoring.Mail.Autotests.WebDriver;
using OpenQA.Selenium.Chrome;

namespace Epam.Automation.Mentoring.Mail.Autotests.Utility
{
    public static class ScreenshotTaker
    {

        private static IWebDriver Browser
        {
            get { return MyWebDriver.GetDriver(); }
        }

        public static string TakeScreenshot(string directory, IWebDriver driver, string testName)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }


            string screenshotFileName =
                string.Format(
                    "{0}_{1}.{2}",
                    testName,
                  
                    DateTime.Now.ToString("dd.MM.yyyy_HH.mm.ss"),
                    ImageFormat.Jpeg.ToString().ToLowerInvariant())
                      .Replace("\"", string.Empty)
                      .Replace("\\", string.Empty);

            string screenshotSaveFullPath = Path.Combine(directory, screenshotFileName);

            var ss = ((ITakesScreenshot)Browser).GetScreenshot();
            ss.SaveAsFile(screenshotSaveFullPath);

            return screenshotSaveFullPath;
        }
    }
}
