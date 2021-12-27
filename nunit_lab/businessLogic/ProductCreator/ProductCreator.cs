using System;
using System.Text;
using OpenQA.Selenium;
using nunit_lab.dto.Product;
using nunit_lab.page_objects;


using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using NUnit.Framework;

using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support;



namespace nunit_lab.businessLogic.ProductCreator
{
    internal class ProductCreator

    {
        private IWebDriver driver;
        Product product1 = new Product("Product1", "Dairy Products", "Exotic Liquids", "10", "1 box", "6", "3", "0");
        


        public ProductPage CreateProduct()
        {
            ProductPage productPage1;
            CreatePage createPage1 = new CreatePage(driver);
            createPage1.FieldProductNameFill(product1.ProductName);
            createPage1.FieldCategoryIdFill(product1.ProductName);
            createPage1.FieldSupplierIdFill(product1.ProductName);
            createPage1.FieldUnitPriceFill(product1.ProductName);
            createPage1.FieldQuantityPerUnitFill(product1.ProductName);
            createPage1.FieldUnitsInStockFill(product1.ProductName);
            createPage1.FieldUnitsOnOrderFill(product1.ProductName);
            createPage1.FieldReorderLevelFill(product1.ProductName);
            productPage1 = createPage1.CreateProduct();
            return productPage1;


        }
    }
}
