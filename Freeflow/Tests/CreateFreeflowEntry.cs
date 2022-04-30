using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Freeflow.Helpers;
using Freeflow.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using static Freeflow.Helpers.CommonMethods;

namespace Freeflow.NUnitTests
{
    [TestFixture]
    public class FreeflowFeature : CommonDriver
    {
        private static ExtentTest test;
        private static ExtentReports extent;        

        [OneTimeSetUp]
        public void Start()
        {
            // Open chrome browser, no login required for this test
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(ConstantUtils.Url);

            // Initialize ExtentReports
            var htmlReporter = new ExtentHtmlReporter(ConstantUtils.ReportsPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);

            FreeflowPage freeflowPageObj = new FreeflowPage(driver);
        }


        [Test]
        public void T01_CreateFreeflowEntry_Pass()
        {
            try
            {
                // Create Extentreport test
                test = extent.CreateTest(System.Reflection.MethodBase.GetCurrentMethod().Name);

                // Initializing page objects (Page Factory)
                FreeflowPage freeflowPageObj = new FreeflowPage(driver);

                // Create Freeflow entry
                freeflowPageObj.CreateEntry();

                // Take a screenshot
                string img = SaveScreenShotClass.SaveScreenshot(driver, "Screenshot");
                test.AddScreenCaptureFromPath(img);

                // Get entered info
                string enteredRandomText = freeflowPageObj.GetEnteredRandomText();
                string enteredRandomPlanet = freeflowPageObj.GetEnteredRandomPlanet();

                // Assertion
                Assert.That(enteredRandomText, Is.EqualTo("ten"));
                Assert.That(enteredRandomPlanet, Is.EqualTo("earth"));

                // Log status in Extentreports
                test.Log(Status.Pass, "Passed, Create Freeflow entry successfull");
            }
            catch (Exception e)
            {
                // Log status in Extentreports
                test.Log(Status.Fail, "Failed, Create Freeflow entry unsuccessfull");
                test.Log(Status.Info, e.Message);
            }
        }

        [Test]
        public void T02_CreateFreeflowEntry_Fail()
        {
            try
            {
                // Create Extentreport test
                test = extent.CreateTest(System.Reflection.MethodBase.GetCurrentMethod().Name);

                // Initializing page objects (Page Factory)
                FreeflowPage freeflowPageObj = new FreeflowPage(driver);

                // Create Freeflow entry
                freeflowPageObj.CreateEntry();

                // Take a screenshot
                string img = SaveScreenShotClass.SaveScreenshot(driver, "Screenshot");
                test.AddScreenCaptureFromPath(img);

                // Get entered info
                string enteredRandomText = freeflowPageObj.GetEnteredRandomText();
                string enteredRandomPlanet = freeflowPageObj.GetEnteredRandomPlanet();

                // Assertion
                Assert.That(enteredRandomText, Is.EqualTo("nine"));
                Assert.That(enteredRandomPlanet, Is.EqualTo("earth"));

                // Log status in Extentreports
                test.Log(Status.Pass, "Passed, Create Freeflow entry successfull");
            }
            catch (Exception e)
            {
                // Log status in Extentreports
                test.Log(Status.Fail, "Failed, Create Freeflow entry unsuccessfull");
                test.Log(Status.Info, e.Message);
            }
        }


        [OneTimeTearDown]
        public void CloseTestRun()
        {
            // Close the browser
            driver.Quit();

            // Save Extentereport html file
            extent.Flush();
        }
    }
}