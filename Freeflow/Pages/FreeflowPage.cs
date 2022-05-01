using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace Freeflow.Pages
{
    public class FreeflowPage
    {
        public FreeflowPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        #region  Initialize Web Elements (Page Factory style)

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Create')]")]
        public IWebElement createButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='edit-field-freeflow-random-text-0-value']")]
        public IWebElement randomTextTextbox { get; set; }

        [FindsBy(How = How.XPath, Using = "//option[contains(text(),'earth')]")]
        public IWebElement randomPlanetOption { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='edit-submit']")]
        public IWebElement saveButton { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//*[@id='block-views-block-freeflow-block-1']/div/div/div/div[2]/table/tbody/tr[1]/td[1]")]
        public IWebElement getEnteredRandomText { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='block-views-block-freeflow-block-1']/div/div/div/div[2]/table/tbody/tr[1]/td[2]")]
        public IWebElement getEnteredRandomPlanet { get; set; }

        #endregion

        public void CreateEntry() 
        {
            // Click create button
            createButton.Click();            

            // Enter random text textbox
            randomTextTextbox.SendKeys("ten");

            // Select random planet
            randomPlanetOption.Click();

            // Click save button            
            saveButton.Click();
        }

        #region  Getting entered data

        public string GetEnteredRandomText()
        {
            return getEnteredRandomText.Text;
        }

        public string GetEnteredRandomPlanet()
        {
            return getEnteredRandomPlanet.Text;
        }

        #endregion
    }
}