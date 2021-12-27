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
    public class CreateProductStepDefinitions
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        Product product1 = new Product("Product1", "Dairy Products", "Exotic Liquids", "10", "1 box", "6", "3", "0");
        [BeforeScenario]

        [Given(@"\[I pass authorisation]")]
        public void GivenIPassAuthorisation()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://localhost:5000/Account/Login");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            throw new PendingStepException();
        }

        [When(@"\[I go to ""([^""]*)""]")]
        public void WhenIGoTo(string CreatePage)
        {
            LoginPage loginPage = new LoginPage(driver);
            HomePage homePage = loginPage.Login();
            ProductPage productPage1 = homePage.GoToProducts();
            CreatePage createPage = productPage1.CreateProduct();
            Thread.Sleep(1000);
        }

        [When(@"I fill ""([^""]*)""")]
        public void WhenIFill(string fields)
        {
            ProductCreator productCreator = new ProductCreator();
            ProductPage productPage2 = productCreator.CreateProduct();
            Assert.AreEqual(productPage2.lastelement.Text, product1.ProductName);
        }

        [Then(@"\[I go to ""([^""]*)""]")]
        public void ThenIGoTo(string homePage)
        {
            throw new PendingStepException();
        }
        [AfterScenario]
        public void AfterScenario()
        {
            driver.Close();
        }
    }
}
