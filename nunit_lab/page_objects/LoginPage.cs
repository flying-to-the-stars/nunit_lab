using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support;



namespace nunit_lab.page_objects
{
    class LoginPage:AbstractPage
    {

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "Name")]
        private IWebElement login_1;

        [FindsBy(How = How.Id, Using = "Password")]
        private IWebElement password_1;

        public HomePage Login()
        {
            IAction action = new Actions(driver)
            .Click(login_1)
            .SendKeys("user")
            .Click(password_1)
            .SendKeys("user")
            .SendKeys(Keys.Enter)
            .Build();

            action.Perform(); 
            return new HomePage(driver);
        }
    }
}
