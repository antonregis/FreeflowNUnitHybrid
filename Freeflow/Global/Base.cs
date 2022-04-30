using Freeflow.Helpers;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;


namespace Freeflow.Global
{
    class Base 
    {
        [SetUp]
        public void LoadBrowser()
        {
            // Open chrome browser, no login required for this test
            CommonDriver.driver = new ChromeDriver();
            CommonDriver.driver.Manage().Window.Maximize();
            CommonDriver.driver.Navigate().GoToUrl(ConstantUtils.Url);            
        }

        [TearDown]
        public void CloseBrowser()
        {
            // Close the browser
            CommonDriver.driver.Quit();
        }
    }
}