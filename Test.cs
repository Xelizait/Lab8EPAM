using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8EPAM
{
    [TestFixture]
    public class Test    
    {

        WebDriver driver;

        [SetUp]
        public void StartPageSetup()
        {
            driver = new EdgeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }

        [Test]
        public void FastBuy()
        {
            var libertexPage = new LibertexPage(driver);
            libertexPage.OpenPage().Login().CreateBuyDeal();
            Assert.AreEqual(libertexPage.OrderCurrency.Text, "EUR/USD");
            Assert.AreEqual(libertexPage.OrderValue.Text, "$5 000");
            Assert.AreEqual(libertexPage.OrderNumber.Text, "100");
        }

        [Test]
        public void FastCloseAll()
        {
            var libertexPage = new LibertexPage(driver);
            libertexPage.OpenPage().Login().CloseAllDeals();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(8);
            Assert.AreEqual(libertexPage.InvestedMoneyText.Text, "$0.00");
        }
    }
}
