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

        public  object FieldProductNameFill(string productname_to_set)
        {
            new Actions(driver)
                .Click(productname)
                .SendKeys(productname_to_set)
                .Build()
                .Perform();
            return productname;
        }

        public void FieldCategoryIdFill(string category_to_set)
        {
            new Actions(driver)
                .Click(categoryid)
                .SendKeys(category_to_set)
                .Build()
                .Perform();
            //return productname;
        }

        public void FieldSupplierIdFill(string supplier_to_set)
        {
            new Actions(driver)
                .Click(supplierid)
                .SendKeys(supplier_to_set)
                .Build()
                .Perform();
        }

        public void FieldUnitPriceFill(string unitprice_to_set)
        {
            new Actions(driver)
                .Click(supplierid)
                .SendKeys(unitprice_to_set)
                .Build()
                .Perform();
        }

        public void FieldQuantityPerUnitFill(string QuantityPerUnit_to_set)
        {
            new Actions(driver)
                .Click(QuantityPerUnit)
                .SendKeys(QuantityPerUnit_to_set)
                .Build()
                .Perform();
        }
        public void FieldUnitsInStockFill(string UnitsInStock_to_set)
        {
            new Actions(driver)
                .Click(UnitsInStock)
                .SendKeys(UnitsInStock_to_set)
                .Build()
                .Perform();
        }

        public void FieldUnitsOnOrderFill(string UnitsOnOrder_to_set)
        {
            new Actions(driver)
                .Click(UnitsOnOrder)
                .SendKeys(UnitsOnOrder_to_set)
                .Build()
                .Perform();
        }

        public void FieldReorderLevelFill(string ReorderLevel_to_set)
        {
            new Actions(driver)
                .Click(ReorderLevel)
                .SendKeys(ReorderLevel_to_set)
                .Build()
                .Perform();
        }
        public ProductPage CreateProduct()
        {
            new Actions(driver)
                .Click(btnSend)
                .Build()
                .Perform();
            return new ProductPage(driver);

        }
    }
}
