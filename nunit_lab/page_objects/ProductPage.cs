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
    
    internal class ProductPage:AbstractPage
    {
        public ProductPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }
        [FindsBy(How = How.XPath, Using = "//div[2]/a")]
        private IWebElement createnew;

        [FindsBy(How = How.XPath, Using = "//li[4]/a")]
        private IWebElement logout;

        [FindsBy(How = How.XPath, Using = "//tr[last()]/td[2]/a")]
        public IWebElement lastelement;

        [FindsBy(How = How.XPath, Using = "//tr[last()]/td[12]/a")]
        public IWebElement lastelementRemove;

        [FindsBy(How = How.XPath, Using = "//tr[last()]/td[3]/a")]
        public IWebElement lastelementCategory;


        public CreatePage CreateProduct()
        {
            new Actions(driver)
                .Click(createnew)
                .Build()
                .Perform();
            return new CreatePage(driver);
        }
        
        public LoginPage Logout()
        {
            new Actions(driver)
                .Click(logout)
                .Build()
                .Perform();
            return new LoginPage(driver);
        }
        public EditPage OpenCreatedProduct()
        {
            new Actions(driver)
                .Click(lastelement)
                .Build()
                .Perform();
            return new EditPage(driver);
        }
        public void RemoveProduct()
        {
            new Actions(driver)
                .Click(lastelementRemove)
                .Build()
                .Perform();
            
        }


    }

}
