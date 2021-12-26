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

namespace nunit_lab.page_objects
{
    public class Tests
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        public string productname_to_set = "Product1";
        public string category_to_set = "Dairy Products";
        public string supplier_to_set = "Exotic Liquids";
        public string unitprice_to_set = "10";
        public string QuantityPerUnit_to_set = "1 box";
        public string UnitsInStock_to_set = "6";
        public string UnitsOnOrder_to_set = "3";
        public string ReorderLevel_to_set = "0";
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://localhost:5000/Account/Login");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            LoginPage loginPage = new LoginPage(driver);
            HomePage homePage = loginPage.Login();
        }
        [Test]
        public void TestLogin()
        {
            LoginPage loginPage = new LoginPage(driver);
            HomePage homePage = loginPage.Login();
            Assert.AreEqual(homePage.titleHomepage, "Home page");
        }

        [Test]
        public void TestAddNewProduct()

        {
            LoginPage loginPage = new LoginPage(driver);
            HomePage homePage = loginPage.Login();
            ProductPage productPage1 = homePage.GoToProducts();
            CreatePage createPage = productPage1.CreateProduct();
            ProductPage productPage2 = createPage.CreateProduct
                (
                productname_to_set, category_to_set, supplier_to_set
                , unitprice_to_set, QuantityPerUnit_to_set, UnitsInStock_to_set
                , UnitsOnOrder_to_set, ReorderLevel_to_set
                );
            Assert.AreEqual(productPage2.lastelement.Text, productname_to_set);
        }
        [Test]
        public void TestopencreatedProduct()
        {
            LoginPage loginPage = new LoginPage(driver);
            HomePage homePage = loginPage.Login();
            ProductPage productPage1 = homePage.GoToProducts();
            EditPage editPage = productPage1.OpenCreatedProduct();
            Assert.AreEqual(productname_to_set, productPage1.lastelement.Text);

            Assert.AreEqual(category_to_set, productPage1.lastelementCategory.Text);
        }
        [Test]
        public void Testdeleteproduct()
        {
            LoginPage loginPage = new LoginPage(driver);
            HomePage homePage = loginPage.Login();
            ProductPage productPage1 = homePage.GoToProducts();
            productPage1.RemoveProduct();
            if (productPage1.lastelement.Text == productname_to_set)
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
