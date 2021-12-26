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
    internal class CreatePage : AbstractPage
    {
        public CreatePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }

        [FindsBy(How = How.Id, Using = "ProductName")]
        public IWebElement productname;

        [FindsBy(How = How.Id, Using = "CategoryId")]
        public IWebElement categoryid;

        [FindsBy(How = How.Id, Using = "SupplierId")]
        public IWebElement supplierid;

        [FindsBy(How = How.Id, Using = "UnitPrice")]
        public IWebElement unitPrice;

        [FindsBy(How = How.Id, Using = "QuantityPerUnit")]
        public IWebElement QuantityPerUnit;

        [FindsBy(How = How.Id, Using = "UnitsInStock")]
        public IWebElement UnitsInStock;

        [FindsBy(How = How.Id, Using = "UnitsOnOrder")]
        public IWebElement UnitsOnOrder;

        [FindsBy(How = How.Id, Using = "ReorderLevel")]
        public IWebElement ReorderLevel;

        [FindsBy(How = How.XPath, Using = "//input[@class = \"btn btn-default\"]")]
        public IWebElement btnSend;


        public ProductPage CreateProduct(string productname_to_set, string category_to_set
            , string supplier_to_set, string unitprice_to_set, string QuantityPerUnit_to_set
            , string UnitsInStock_to_set, string UnitsOnOrder_to_set, string ReorderLevel_to_set)
        {
            new Actions(driver)
                .SendKeys(productname_to_set)
                .Click(categoryid)
                .SendKeys(category_to_set)
                .Click(supplierid)
                .SendKeys(supplier_to_set)
                .Click(unitPrice)
                .SendKeys(unitprice_to_set)
                .Click(QuantityPerUnit)
                .SendKeys(QuantityPerUnit_to_set)
                .Click(UnitsInStock)
                .SendKeys(UnitsInStock_to_set)
                .Click(UnitsOnOrder)
                .SendKeys(UnitsOnOrder_to_set)
                .Click(ReorderLevel)
                .SendKeys(ReorderLevel_to_set)
                .Click(btnSend)
                .Build()
                .Perform();
            return new ProductPage(driver);

        }
    }
}
