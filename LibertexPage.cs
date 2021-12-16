using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace Lab8EPAM
{
    public class LibertexPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public IWebElement LogInMenuButton => _wait.Until(_driver => _driver.FindElement(By.CssSelector("div.col-mid > a")));
        public IWebElement InputEmail => _wait.Until(_driver => _driver.FindElement(By.CssSelector("input[type=text]")));
        public IWebElement InputPassword => _wait.Until(_driver => _driver.FindElement(By.CssSelector("input[type=password]")));
        public IWebElement LogInButton => _wait.Until(_driver => _driver.FindElement(By.CssSelector("input[type=submit]")));
        public IWebElement BuyButton => _wait.Until(_driver => _driver.FindElement(By.CssSelector("div.chart-head-inner > a.a-btn.new-invest.growth")));
        public IWebElement SelectPriceField => _wait.Until(_driver => _driver.FindElement(By.XPath("//*[@id=\"sumInv\"]")));
        public IWebElement SelectPriceDropmenu => _wait.Until(_driver => _driver.FindElement(By.XPath("(//li[@class=\"ui-menu-item selected\"])[1]")));
        public IWebElement ConfirmBuyingButton => _wait.Until(_driver => _driver.FindElement(By.CssSelector("div.a-submit")));
        public IWebElement UnderstandButton => _wait.Until(_driver => _driver.FindElement(By.CssSelector("span.a-btn.a-btn-trans.a-invest-close")));
        public IWebElement NotNowButton => _wait.Until(_driver => _driver.FindElement(By.CssSelector("span.a-btn.a-btn-trans.close")));

        public LibertexPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, System.TimeSpan.FromSeconds(15));
        }

        public LibertexPage OpenPage()
        {
            _driver.Navigate().GoToUrl("https://libertex.fxclub.by/register");
            return this;
        }

        public LibertexPage Login()
        {
            LogInMenuButton.Click();
            InputEmail.SendKeys("testingepam@rambler.ru");
            InputPassword.SendKeys("AdminAdmin321");
            LogInButton.Click();
            return this;
        }
    }
}
