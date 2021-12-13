using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace NUnitTestProject1
{
    public class Tests
    {
        IWebDriver driver;

         
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl("https://www2.hm.com/ru_ru/index.html");
        }


        [Test]
        public void NegativeSignUpTest()
        {
            driver.FindElement(By.XPath("//*[contains(@class,'account parbase')]")).Click();
            driver.FindElement(By.XPath("//*[contains(@id,'modal-txt-signin-email')]")).SendKeys("Test23@mail.ru");
            driver.FindElement(By.XPath("//*[contains(@id,'modal-txt-signin-password')]")).SendKeys("1234");
            driver.FindElement(By.XPath("//*[contains(@class, 'button large js-set-session-storage btn-login')]")).Click();

            Assert.IsTrue(driver.FindElement(By.CssSelector("#modal-txt-signin-password-unknown-error-type-error")).Displayed, "Ќеправильный адрес электронной почты или пароль, повторите попытку.");
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}