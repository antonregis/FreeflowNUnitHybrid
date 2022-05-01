using Freeflow.Config;
using Freeflow.Helpers;
using Freeflow.Pages;
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
            CommonDriver.driver.Navigate().GoToUrl(FreeflowResource.Url);

            try
            {
                // Log in to website
                LogIn logInPageObj = new LogIn(CommonDriver.driver);
                logInPageObj.LogInSteps();
            }
            catch (Exception ex) 
            {
                Assert.Fail("Freeflow login page did not launch", ex.Message);
                throw;
            }
        }

        [TearDown]
        public void CloseBrowser()
        {
            // Close the browser
            CommonDriver.driver.Quit();
        }
    }
}