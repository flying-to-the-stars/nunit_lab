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
using PageFactoryCore;
using nunit_lab.businessLogic.ProductCreator;
using nunit_lab.dto.Product;

namespace nunit_lab.page_objects
{
    public class Tests
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        Product product1 = new Product("Product1", "Dairy Products", "Exotic Liquids", "10", "1 box", "6", "3", "0");
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://localhost:5000/Account/Login");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            
        }
        [Test]
        public void TestLogin()
        {
            LoginPage loginPage = new LoginPage(driver);
            Thread.Sleep(1000);
            HomePage homePage = loginPage.Login();
            Assert.AreEqual(homePage.titleHomepage.Text, "Home page");
        }

        [Test]
        public void TestAddNewProduct()

        {
            LoginPage loginPage = new LoginPage(driver);
            HomePage homePage = loginPage.Login();
            ProductPage productPage1 = homePage.GoToProducts();
            CreatePage createPage = productPage1.CreateProduct();
            Thread.Sleep(1000);
            ProductCreator productCreator = new ProductCreator();
            ProductPage productPage2 = productCreator.CreateProduct();
            
            Assert.AreEqual(productPage2.lastelement.Text, product1.ProductName);
        }
        [Test]
        public void TestopencreatedProduct()
        {
            LoginPage loginPage = new LoginPage(driver);
            HomePage homePage = loginPage.Login();
            ProductPage productPage1 = homePage.GoToProducts();
            EditPage editPage = productPage1.OpenCreatedProduct();
            Assert.AreEqual(product1.ProductName, productPage1.lastelement.Text);

            Assert.AreEqual(product1.CategoryId, productPage1.lastelementCategory.Text);
        }
        [Test]
        public void Testdeleteproduct()
        {
            LoginPage loginPage = new LoginPage(driver);
            HomePage homePage = loginPage.Login();
            ProductPage productPage1 = homePage.GoToProducts();
            productPage1.RemoveProduct();
            if (productPage1.lastelement.Text == product1.ProductName)
            {
                try
                {
                    productPage1.lastelement.Click();
                }
                catch (NoSuchElementException ex)
                {
                    Assert.Pass(ex.Message);

                }
            }
        }
        [TearDown]
        public void Teardown()
        {
            driver.Close();
        }
    }
}
