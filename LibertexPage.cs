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
        public IWebElement OrderCurrency => _wait.Until(_driver => _driver.FindElement(By.XPath("//*[@id=\"region-active-investments\"]/div/div/div[5]/div/div[1]/div/div[1]/div[1]/div[1]/span[1]")));
        public IWebElement OrderValue => _wait.Until(_driver => _driver.FindElement(By.XPath("//*[@id=\"region-active-investments\"]/div/div/div[5]/div/div[1]/div/div[1]/div[2]/div[2]/span[1]")));
        public IWebElement OrderNumber => _wait.Until(_driver => _driver.FindElement(By.XPath("//*[@id=\"region-active-investments\"]/div/div/div[5]/div/div[1]/div/div[1]/div[2]/div[2]/span[2]")));
        public IWebElement ActiveDealsButton => _wait.Until(_driver => _driver.FindElement(By.XPath("//*[@id=\"region-header\"]/div[2]/div[1]/div[4]/a[1]")));
        public IWebElement CloseAllDealsDropmenu => _wait.Until(_driver => _driver.FindElement(By.XPath("//*[@id=\"region-multiple-close-main\"]/div/div")));
        public IWebElement CloseAllDealsButton => _wait.Until(_driver => _driver.FindElement(By.XPath("//*[@id=\"region-multiple-close-main\"]/div/ul/li[3]")));
        public IWebElement ConfirmClosingButton => _wait.Until(_driver => _driver.FindElement(By.XPath("//*[@id=\"modal\"]/div/div[2]/span[2]")));
        public IWebElement BackToInvestigationsButton => _wait.Until(_driver => _driver.FindElement(By.CssSelector("span.a-btn.a-btn-blue.go-trade")));
        //public IWebElement NoActiveDealsText => _wait.Until(_driver => _driver.FindElement(By.CssSelector("#region-main > div > div.no-active-investments > h3")));
        public IWebElement InvestedMoneyText => _wait.Until(_driver => _driver.FindElement(By.XPath("//*[@id=\"region-main\"]/div/div[6]/div[2]")));
        


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

        public LibertexPage CreateBuyDeal()
        {
            BuyButton.Click();
            SelectPriceField.Click();
            SelectPriceDropmenu.Click();
            ConfirmBuyingButton.Click();
            UnderstandButton.Click();
            NotNowButton.Click();
            return this;
        }
        public LibertexPage CloseAllDeals()
        {
            ActiveDealsButton.Click();
            CloseAllDealsDropmenu.Click();
            CloseAllDealsButton.Click();
            ConfirmClosingButton.Click();
            BackToInvestigationsButton.Click();
            return this;
        }
    }
}
