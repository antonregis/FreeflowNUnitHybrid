using Freeflow.Config;
using Freeflow.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace Freeflow.Pages
{
    public class LogIn
    {
        public LogIn(IWebDriver driver) 
        {
            PageFactory.InitElements(driver, this);
        }

        #region  Initialize Web Elements (Page Factory style)

        [FindsBy(How = How.Id, Using = "edit-name")]
        public IWebElement usernameTextbox { get; set; }

        [FindsBy(How = How.Id, Using = "edit-pass")]
        public IWebElement passwordTextbox { get; set; }

        [FindsBy(How = How.Id, Using = "edit-submit")]
        public IWebElement loginButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Logout')]")] 
        public  IWebElement logoutButton { get; set; }

        #endregion


        public void LogInSteps() 
        {
            // Performing ExcelDataReader 

            // Referencing to an excel file and sheet name
            ExcelLibHelper.PopulateInCollection(FreeflowResource.ExcelPath, "Credentials");

            // Picking up excel data from "username" column, in row 2
            usernameTextbox.SendKeys(ExcelLibHelper.ReadData(2, "username"));

            // Picking up excel data from "password" column, in row 2
            passwordTextbox.SendKeys(ExcelLibHelper.ReadData(2, "password"));

            // Click login button
            loginButton.Click(); 
            
            // Go to Freeflow url
            CommonDriver.driver.Navigate().GoToUrl(FreeflowResource.UrlFreeflow);
        }
    }
}
