using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using Xunit;

namespace Epam.Automation.Mentoring.Mail.Autotests
{
    public class AutomatedUITests : IDisposable
    {
        //Создаем новый объект ChromeDriver в конструкторе
        private readonly IWebDriver driver;
        public AutomatedUITests()
        {
            driver = new ChromeDriver();
        }

        [Fact] //Тестовый случай, аналогичен TestCase    
        public void Email_Create_Validate_Send_Test()
        {
            //Объявляем переменные для простоты работы
            string email = "tst_atmp_2020q2";
            string password = "Administratum4199";
            string adressee = "nrco@mail.ru";
            string topic = "Just for test 55";
            string text = "Something for testing purposes";
            By searchEmailAndTopicToValidate = By.XPath("//div[@class='dataset-letters']//span[@title='" + adressee + "']" +
            "/parent::div/following-sibling::div[contains(@class, 'llc__item_title')]//span[text()='" + topic + "']");
            By testText = By.XPath(".//div[@data-name='to']//input[starts-with(@type, 'text')]");
            TimeSpan timeout = TimeSpan.FromSeconds(30); //задаем сколько времени селениум будет ждать сл. действия

            CustomDriver cDriver = new CustomDriver();
            //Переходим на сайт и подтверждаем, что это тот сайт, что нам нужен
            driver.Navigate().GoToUrl("https://mail.ru/");
            Assert.Equal("Mail.ru: почта, поиск в интернете, новости, игры", driver.Title);

            //Логинимся
            driver.FindElement(By.Id("mailbox:login")).SendKeys(email);
            driver.FindElement(By.Id("mailbox:submit")).Click();
            cDriver.SendKeys(driver, By.Id("mailbox:password"), password);
            cDriver.Click(driver, By.Id("mailbox:submit"));

            //Кликаем на кнопку создания нового письма (работает на любом разрешении)
            cDriver.Click(driver, By.XPath(".//span[@class='compose-button__wrapper']"));
            
            //Заполняем получателя, тему и текст письма
            cDriver.SendKeys(driver, testText, adressee);
            driver.FindElement(By.XPath(".//input[starts-with(@name, 'Subject')]")).SendKeys(topic);
            driver.FindElement(By.XPath(".//div[@role='textbox']/div[1]")).SendKeys(text);

            //Сохраняем письмо и закрываем его
            driver.FindElement(By.XPath(".//span[@title='Сохранить']")).Click();
            driver.FindElement(By.XPath(".//button[@title='Закрыть']")).Click();
            driver.FindElement(By.XPath(".//div[@class='nav-folders']//a[@href='/drafts/']")).Click();

            //Проверяем наличие и содержание письма
            //Можно проверять присутствие элемента так
            cDriver.CheckIfPresent(driver, searchEmailAndTopicToValidate);
            Boolean isEmailPresent = driver.FindElements(searchEmailAndTopicToValidate).Count > 0;
            Assert.True(isEmailPresent);
            driver.FindElement(By.XPath("//div[@class='dataset-letters']//span[@title='" + adressee + "']/parent::div/following-sibling::div[contains(@class, 'llc__item_title')]//span[text()='" + topic + "']")).Click();
            //Можно сразу подставлять поиск элемента в Assert и проверять, но тогда не всегда очевидно, что мы проверяем, без доп. коментариев
            cDriver.CheckIfPresent(driver, By.XPath(".//div[@role='textbox']//div[text()='" + text + "']"));
            Assert.True(driver.FindElements(By.XPath(".//div[@role='textbox']//div[text()='" + text + "']")).Count > 0);
            Assert.True(driver.FindElements(By.XPath(".//div[@data-name='to']//div[@title='" + adressee + "']")).Count > 0);
            Assert.True(driver.FindElements(By.XPath(".//input[@name='Subject' and @value='" + topic + "']")).Count > 0);

            //Отправляем и закрываем модальное окно
            driver.FindElement(By.XPath(".//span[@title='Отправить']")).Click();
            cDriver.Click(driver, By.XPath(".//span[@title='Закрыть']"));
            //driver.FindElement(By.XPath(".//span[@title='Закрыть']")).Click();

            //Проверяем, что письма нет в Черновиках
            WebDriverWait wait = new WebDriverWait(driver, timeout);
            //Замена на deprecated ExpectedConditions на функцию взятую из кода Selenium
            wait.Until(CustomDriver.InvisibilityOfElementLocated(searchEmailAndTopicToValidate));
            Assert.False(driver.FindElements(searchEmailAndTopicToValidate).Count > 0);

            //Переходим в отправленные и проверяем там наличие письма
            driver.FindElement(By.XPath(".//div[@class='nav-folders']//a[@href='/sent/']")).Click();

            //Замена Thread.Sleep и deprecated ExpectedCondition на самописный метод ожидания
            cDriver.CheckIfPresent(driver, searchEmailAndTopicToValidate);
            Assert.True(driver.FindElements(searchEmailAndTopicToValidate).Count > 0);

            //Выходим
            driver.FindElement(By.XPath(".//a[@title='выход']")).Click();
            System.Threading.Thread.Sleep(3000); //для визуального просмотра результатов теста only, удаляем после вывода в production
        }

        //Аналогичен Clean
        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
