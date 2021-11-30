using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class ShippingTaxEstimate
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://www.google.com/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheShippingTaxEstimateTest()
        {
            driver.FindElement(By.LinkText("Your Store")).Click();
            driver.FindElement(By.XPath("//div[@id='content']/div[2]/div[2]/div/div/a/img")).Click();
            driver.FindElement(By.Id("input-quantity")).Click();
            driver.FindElement(By.Id("input-quantity")).Clear();
            driver.FindElement(By.Id("input-quantity")).SendKeys("2");
            driver.FindElement(By.Id("button-cart")).Click();
            driver.FindElement(By.XPath("//div[@id='cart']/button")).Click();
            driver.FindElement(By.XPath("//div[@id='cart']/ul/li[2]/div/p/a/strong")).Click();
            driver.Navigate().GoToUrl("https://demo.opencart.com/index.php?route=common/home");
            driver.FindElement(By.Id("cart-total")).Click();
            driver.FindElement(By.XPath("//div[@id='cart']/ul/li[2]/div/p/a/strong")).Click();
            driver.FindElement(By.XPath("//div[@id='accordion']/div[2]/div/h4/a/i")).Click();
            driver.FindElement(By.Id("input-zone")).Click();
            new SelectElement(driver.FindElement(By.Id("input-zone"))).SelectByText("Aberdeen");
            driver.FindElement(By.Id("input-postcode")).Click();
            driver.FindElement(By.Id("input-postcode")).Clear();
            driver.FindElement(By.Id("input-postcode")).SendKeys("353324");
            driver.FindElement(By.Id("button-quote")).Click();
            driver.FindElement(By.XPath("//div[@id='modal-shipping']/div/div/div[2]/div/label")).Click();
            driver.FindElement(By.Id("button-shipping")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
