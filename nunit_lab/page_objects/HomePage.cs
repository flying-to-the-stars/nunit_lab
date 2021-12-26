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

namespace nunit_lab.page_objects
{
    class HomePage : AbstractPage
    {
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//li[2]/a")]
        private IWebElement allproduct;

        [FindsBy(How = How.TagName, Using = "h2")]
        public IWebElement titleHomepage;

        public ProductPage GoToProducts()
        {
            IAction action = new Actions(driver)
            .Click(allproduct)
            .Build();

            action.Perform();
            return new ProductPage(driver);
        }

    }
}
        