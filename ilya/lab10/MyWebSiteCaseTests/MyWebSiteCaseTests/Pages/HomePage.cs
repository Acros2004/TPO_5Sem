using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSiteCaseTests.Pages
{
    public class HomePage : AbstractPage
    {
        private string url = "https://www.twitch.tv/";

        public HomePage(IWebDriver webDriver) : base(webDriver) { }
        public void ClickButton(By locator)
        {
            driver.FindElement(locator).Click();
        }
        public void ClickProfileButton()
        {
            ClickButton(By.XPath("//*[@id=\"root\"]/div/div[2]/nav/div/div[3]/div[3]/div/div[2]/div/div[1]/button/button"));
        }

        public void ClickSwitchThemesButton()
        {
            ClickButton(By.XPath("/html/body/div[5]/div/div/div/div/div/div/div/div/div/div/div/div[3]/div/div/div[2]/div/div/div[2]"));
        }

        public void Login(string login, string password)
        {
            ClickButton(By.XPath("//*[@id=\"root\"]/div/div[2]/nav/div/div[3]/div[3]/div/div[1]/div[1]/button"));
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id=\"login-username\"]")).SendKeys(login);
            driver.FindElement(By.XPath("//*[@id=\"password-input\"]")).SendKeys(password);
            Thread.Sleep(10000);
        }

        public string GetTheme()
        {
            IWebElement body = driver.FindElement(By.TagName("body"));
            string backgroundColor = body.GetCssValue("background-color");
            return backgroundColor;
        }

        public string GetCurrentCategory()
        {
            IWebElement category = driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div[2]/div/main/div[1]/div[3]/div/div/div/div/div[1]/div[3]/div[1]/h2/div"));
            return category.Text.Trim();
        }

        public override void GoToPage()
        {
            driver.Navigate().GoToUrl(url);
        }
    }
}
