using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8EPAM
{
    public class Test
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        private const string TestEmail = "xelizait@bk.ru";
        private const string TestPassword = "Admin123";

        [SetUp]
        public void StartPageSetup()
        {
            _driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            _wait = new WebDriverWait(_driver, System.TimeSpan.FromSeconds(15));
            _driver.Navigate().GoToUrl("https://libertex.fxclub.by/register");
            _driver.Manage().Window.Maximize();

            var logInMenuButton = _wait.Until(_driver => _driver.FindElement(By.CssSelector("div.col-mid > a")));
            logInMenuButton.Click();

            var inputEmail = _wait.Until(_driver => _driver.FindElement(By.CssSelector("input[type=text]")));
            inputEmail.SendKeys(TestEmail);

            var inputPassword = _driver.FindElement(By.CssSelector("input[type=password]"));
            inputPassword.SendKeys(TestPassword);

            var logInButton = _driver.FindElement(By.CssSelector("input[type=submit]"));
            logInButton.Click();
        }

        [Test]
        public void CreateDealToBuyTest()
        {
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));

            var buyButton = _wait.Until(_driver => _driver.FindElement(By.CssSelector("div.chart-head-inner > a.a-btn.new-invest.growth")));
            buyButton.Click();

            var priceButton = _wait.Until(_driver => _driver.FindElement(By.XPath("//*[@id=\"sumInv\"]")));
            priceButton.Click();

            var priceSelect = _wait.Until(_driver => _driver.FindElement(By.XPath("(//li[@class=\"ui-menu-item selected\"])[1]")));
            priceSelect.Click();

            var submitButton = _driver.FindElement(By.CssSelector("div.a-submit"));
            submitButton.Click();

            var okButton = _wait.Until(_driver => _driver.FindElement(By.CssSelector("span.a-btn.a-btn-trans.a-invest-close")));
            okButton.Click();

            var closeWindowButton = _wait.Until(_driver => _driver.FindElement(By.CssSelector("span.a-btn.a-btn-trans.close")));
            closeWindowButton.Click();

            Assert.IsTrue(_driver.FindElements(By.XPath("//*[@id=\"region-active-investments\"]/div/div/div[5]/div/div[1]/div/div[1]")).Count() > 0);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
