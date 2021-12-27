using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Interactions;
using PageFactoryCore;
using nunit_lab.businessLogic.ProductCreator;
using nunit_lab.dto.Product;
using nunit_lab.page_objects;

namespace nunit_lab
{
    [Binding]
    public class LogoutStepDefinitions


    { 
        private IWebDriver driver;
        private WebDriverWait wait;
        [BeforeScenario]
        [Given(@"\[I open ""([^""]*)"" url]")]
        public void GivenIOpenUrl(string p0)
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://localhost:5000/Account/Login");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);

            throw new PendingStepException();

        }
        [Given(@"\[I am on ""([^""]*)""]")]
        public void GivenIAmOn(string homePage)
        {
            throw new PendingStepException();
        }

        [When(@"\[I click logout]")]
        public void WhenIClickLogout()
        {
            throw new PendingStepException();
        }
        [Then(@"\[I go to LoginPage]")]
        public void ThenIGoToLoginPage()
        {
        }
        [AfterScenario]
        public void AfterScenario()
        {
            driver.Close();
        }
    }
}
