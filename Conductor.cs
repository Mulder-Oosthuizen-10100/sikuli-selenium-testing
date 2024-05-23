using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SikuliSharp;

namespace Capstone_Project
{
    public class Conductor
    {
        ISikuliSession session;
        IWebDriver driver;
        ExtentReports report;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            report = new ExtentReports();

            var html_reporter = new ExtentSparkReporter(GlobalFunctions.BasePath('R', "Capstone Test Cases Report.html"));
            report.AttachReporter(html_reporter);

            session = Sikuli.CreateSession();
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void TC_1_Home() // TC = Test_Case...
        {
            ExtentTest test = report.CreateTest("TEST CASE: Open Home Page");
            try
            {
                PageHome.OpenWebsite(driver);
                test.Pass("TEST CASE PASSED");
            }
            catch (Exception ex) 
            {
                test.Fail(ex.Message);
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public void TC_2_Login()
        {
            ExtentTest test = report.CreateTest("TEST CASE: Login to Website");
            try 
            {
                PageLogin.Login(driver);
                test.Pass("TEST CASE PASSED");
            }
            catch (Exception ex)
            {
                test.Fail(ex.Message);
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public void TC_3_Jewelry()
        {
            ExtentTest test = report.CreateTest("TEST CASE: Select Category Jewelry");
            try 
            {
                PageJewelry.SelectCategoryJewelry(driver);
                test.Pass("TEST CASE PASSED");
            }
            catch (Exception ex)
            {
                test.Fail(ex.Message);
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public void TC_4_JewelryListView()
        {
            ExtentTest test = report.CreateTest("TEST CASE: Change View - List");
            try 
            {
                PageJewelry.ChangeView(driver);
                test.Pass("TEST CASE PASSED");
            }
            catch (Exception ex)
            {
                test.Fail(ex.Message);
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public void TC_5_AddJewelryToCart()
        {
            ExtentTest test = report.CreateTest("TEST CASE: Add Product to Cart");
            try 
            {
                PageJewelry.AddProduct(session, driver);
                test.Pass("TEST CASE PASSED");
            }
            catch (Exception ex)
            {
                test.Fail(ex.Message);
                Assert.Fail(ex.Message); 
            }
        }

        [Test]
        public void TC_6_CheckoutProducts()
        {
            ExtentTest test = report.CreateTest("TEST CASE: Checkout Cart");
            try
            {
                PageCart.CheckoutCart(session, driver);
                test.Pass("TEST CASE PASSED");
            }
            catch (Exception ex)
            {
                test.Fail(ex.Message);
                Assert.Fail(ex.Message); 
            }
        }

        [Test]
        public void TC_7_HomeLogout()
        {
            ExtentTest test = report.CreateTest("TEST CASE: Go to Home Page and Logout");
            try 
            {
                PageHome.LogoClickLogoutClick(driver);
                test.Pass("TEST CASE PASSED");
            }
            catch (Exception ex)
            {
                test.Fail(ex.Message);
                Assert.Fail(ex.Message);
            }
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            session.Dispose();
            driver.Dispose();
            report.Flush();
            report = null;
        }
    }
}