using AventStack.ExtentReports;
using Freeflow.Helpers;
using Freeflow.Global;
using Freeflow.Pages;
using NUnit.Framework;
using static Freeflow.Helpers.CommonMethods;
using AventStack.ExtentReports.Reporter;

namespace Freeflow.NUnitTests
{       
  
    [TestFixture]
    class FreeflowFeature : Base
    {
        // Report and Tests for ExtentReports      
        private static ExtentReports extent;
        private static ExtentTest test;


        [OneTimeSetUp]
        public void StartExtentReports() 
        {
            // Initialize ExtentReports
            var htmlReporter = new ExtentHtmlReporter(ConstantUtils.ReportsPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }
        
        
        [Test]
        public void T01_CreateFreeflowEntry_Pass()
        {
            try
            {
                // Create Extentreport test
                test = extent.CreateTest(System.Reflection.MethodBase.GetCurrentMethod().Name);

                // Initializing page objects (Page Factory)
                FreeflowPage freeflowPageObj = new FreeflowPage(CommonDriver.driver);

                // Create Freeflow entry
                freeflowPageObj.CreateEntry();

                // Take a screenshot
                string img = SaveScreenShotClass.SaveScreenshot(CommonDriver.driver, "Screenshot");
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
                FreeflowPage freeflowPageObj = new FreeflowPage(CommonDriver.driver);

                // Create Freeflow entry
                freeflowPageObj.CreateEntry();

                // Take a screenshot
                string img = SaveScreenShotClass.SaveScreenshot(CommonDriver.driver, "Screenshot");
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
        public void SaveExtentReports()
        {
            // Save Extentereport html file
            extent.Flush();
        }
    }
}