using Epam.Automation.Mentoring.Mail.Autotests.WebDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Epam.Automation.Mentoring.Mail.Autotests.UIElements
{
    public class FilesContainer
    {
        private readonly MyWebDriver driver;
        public FilesContainer(MyWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement ClearWaterFile
        {
            get { return this.driver.FindElement(By.XPath("//div[@data-id = '/Чистая вода.jpg']")); }
        }

        public IWebElement Content
        {
            get { return this.driver.FindElement(By.XPath(".//div[@id = 'content']")); }
        }

        public IWebElement CreateCtx
        {
            get { return this.driver.FindElement(By.XPath("//div[@id='react-contextmenu']//div[@data-name = 'create']")); }
        }

        public IWebElement CreateFolderCtxt
        {
            get { return this.driver.FindElement(By.XPath("//div[@data-name = 'createFolder']")); }
        }

        public IWebElement FolderNameInput
        {
            get { return this.driver.FindElement(By.XPath("//input[contains (@placeholder, 'Введите имя папки')]")); }
        }

        public IWebElement CreateFolderAcceptButton
        {
            get { return this.driver.FindElement(By.XPath("//button[@role='button' and text()='Создать']")); }
        }

        public IWebElement Folder
        {
            get { return this.driver.FindElement(By.XPath("//div[@data-id = '/TestFolder1']")); }
        }

        public IWebElement MoveButton
        {
            get { return this.driver.FindElement(By.XPath("//button[@data-name = 'move']")); }
        }

        public void ContextClick()
        {
            Actions action = new Actions(this.driver.webDriver);
            action.MoveToElement(Content).ContextClick().Perform();  
            
        }

        public void CtxCreate()
        {
            Actions action = new Actions(this.driver.webDriver);
            action.MoveToElement(CreateCtx).Build().Perform();
            driver.JsHighlight(CreateCtx);
        }

        public void CtxCreateFolder()
        {
            driver.JsClick(CreateFolderCtxt);
        }

        public void InputFolderNameAndAccept()
        {
            new Actions(this.driver.webDriver)
                .SendKeys(Keys.Backspace)
                .SendKeys(FolderNameInput, "TestFolder1")
                .Click(CreateFolderAcceptButton)
                .Build()
                .Perform();
        }

        public void MoveFileToFolder()
        {
            new Actions(this.driver.webDriver)
                .MoveToElement(ClearWaterFile)
                .DragAndDrop(ClearWaterFile, Folder)
                .Build()
                .Perform();

        }

        public void AcceptMoving()
        {
            MoveButton.Click();
        }

    }
}
