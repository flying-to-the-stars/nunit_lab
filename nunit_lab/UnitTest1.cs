using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Interactions;
using System;


namespace nunit_lab
{
    
    public class Tests
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private string productname_to_set = "Product1";



        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://localhost:5000/Account/Login");
            //Thread.Sleep(1000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement login_1 = driver.FindElement(By.Id("Name"));
            login_1.SendKeys("user");

            IWebElement password_1 = driver.FindElement(By.Id("Password"));

            password_1.SendKeys("user");

            password_1.SendKeys(Keys.Enter);


        }

        [Test, Order(1)]
        public void TestLogin()
        {
            //    IWebElement login_1 = driver.FindElement(By.Id("Name"));
            //    login_1.SendKeys("user");

            //    IWebElement password_1 = driver.FindElement(By.Id("Password"));

            //    password_1.SendKeys("user");

            //    password_1.SendKeys(Keys.Enter);

            IWebElement home_page = driver.FindElement(By.TagName("h2"));
            //    wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Assert.AreEqual(home_page.Text, "Home page");

        }

        [Test, Order(2)]
        public void TestAddNewProduct()

        {
            
            
            driver.Navigate().GoToUrl("http://localhost:5000/");
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            IWebElement allproduct = driver.FindElement(By.XPath("//li[2]/a"));
            allproduct.Click();

            IWebElement createnew = driver.FindElement(By.XPath("//a[@class = \"btn btn-default\"]"));
            createnew.Click();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement productname = driver.FindElement(By.Id("ProductName"));
            productname.SendKeys(productname_to_set);

            SelectElement categoryid = new SelectElement(driver.FindElement(By.Id("CategoryId")));
            categoryid.SelectByText("Dairy Products");

            SelectElement supplierId = new SelectElement(driver.FindElement(By.Id("SupplierId")));
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            supplierId.SelectByText("Exotic Liquids");

            IWebElement unitPrice = driver.FindElement(By.Id("UnitPrice"));
            unitPrice.SendKeys("10");

            IWebElement QuantityPerUnit = driver.FindElement(By.Id("QuantityPerUnit"));
            QuantityPerUnit.SendKeys("1 box");

            IWebElement UnitsInStock = driver.FindElement(By.Id("UnitsInStock"));
            UnitsInStock .SendKeys("6");

            IWebElement UnitsOnOrder = driver.FindElement(By.Id("UnitsOnOrder"));
            UnitsOnOrder.SendKeys("3");

            IWebElement ReorderLevel = driver.FindElement(By.Id("ReorderLevel"));
            ReorderLevel.SendKeys("0");

            IWebElement send_button = driver.FindElement(By.XPath("//input[@class = \"btn btn-default\"]"));
            send_button.Submit();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            

            IWebElement lastelement = driver.FindElement(By.XPath("//tr[last()]/td[2]"));
            string name_of_product = lastelement.Text;

            Assert.AreEqual(productname_to_set, name_of_product);
        }

        [Test, Order(3)]
        public void TestopencreatedProduct()

        {
            driver.Navigate().GoToUrl("http://localhost:5000/Product");
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            IWebElement lastelement = driver.FindElement(By.XPath("//tr[last()]/td[2]/a"));
            //Assert.AreEqual("/Product/Edit?ProductId=84", lastelement.GetAttribute("href"));
            //driver.Navigate().GoToUrl(lastelement.GetAttribute("href"));
            // string index_last_element = lastelement.GetAttribute("href");
            lastelement.Click();
            wait.Until(driver => driver.FindElement(By.Id("ProductName")).Displayed);
            //wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            //все значения в полях следовало бы параметризировать
            Assert.AreEqual(productname_to_set, driver.FindElement(By.Id("ProductName")).Text);

            Assert.AreEqual("Dairy Products", driver.FindElement(By.Id("CategoryId")).Text);

            Assert.AreEqual("Exotic Liquids", driver.FindElement(By.Id("SupplierId")).Text);

            Assert.AreEqual("10", driver.FindElement(By.Id("UnitPrice")).Text);

            Assert.AreEqual("1 box", driver.FindElement(By.Id("QuantityPerUnit")).Text);

            Assert.AreEqual("6", driver.FindElement(By.Id("UnitsInStock")).Text);

            Assert.AreEqual("3", driver.FindElement(By.Id("UnitsOnOrder")).Text);

            Assert.AreEqual("0", driver.FindElement(By.Id("ReorderLevel")).Text);


        }

        [Test, Order(4)]
        public void Testdeleteproduct()
        {
            driver.Navigate().GoToUrl("http://localhost:5000/Product");
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement lastelement_remove = driver.FindElement(By.XPath("//tr[last()]/td[2]/a"));
            if (lastelement_remove.Text == productname_to_set)
            {
                driver.FindElement(By.XPath("//tr[last()]/td[12]/a")).Click();
                driver.SwitchTo().Alert().Accept();
                try
                {
                    driver.FindElement(By.XPath("//tr/td/*[text() = \"Product1\"]")).Click();
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