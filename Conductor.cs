using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SikuliSharp;

namespace Capstone_Project
{
    public class Conductor
    {
        ISikuliSession session;
        IWebDriver driver;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            session = Sikuli.CreateSession();
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void TCHome() // TC = Test_Case...
        {
            try { PageHome.OpenWebsite(driver); }
            catch (Exception ex) { Assert.Fail(ex.Message); }
        }

        [Test]
        public void TCLogin()
        {
            try
            {
                PageHome.OpenWebsite(driver);
                PageLogin.Login(driver);
            }
            catch(Exception ex) { Assert.Fail(ex.Message); }
        }

        [Test]
        public void TCJewelry()
        {
            try
            {
                PageHome.OpenWebsite(driver);
                PageLogin.Login(driver);
                PageJewelry.SelectCategoryJewelry(driver);
            }
            catch (Exception ex) { Assert.Fail(ex.Message); }
        }

        [Test]
        public void TCJewelryListView()
        {
            try
            {
                PageHome.OpenWebsite(driver);
                PageLogin.Login(driver);
                PageJewelry.SelectCategoryJewelry(driver);
                PageJewelry.ChangeView(driver);
            }
            catch (Exception ex) { Assert.Fail(ex.Message); }
        }

        [Test]
        public void TCAddJewelryToCart()
        {
            try
            {
                PageHome.OpenWebsite(driver);
                PageLogin.Login(driver);
                PageJewelry.SelectCategoryJewelry(driver);
                PageJewelry.ChangeView(driver);
                PageJewelry.AddProduct(session, driver);
            }
            catch (Exception ex) { Assert.Fail(ex.Message); }
        }

        [Test]
        public void TCCheckoutProducts()
        {
            try
            {
                PageHome.OpenWebsite(driver);
                PageLogin.Login(driver);
                PageJewelry.SelectCategoryJewelry(driver);
                PageJewelry.ChangeView(driver);
                PageJewelry.AddProduct(session, driver);
                PageCart.CheckoutCart(session, driver);
            }
            catch (Exception ex) { Assert.Fail(ex.Message); }
        }

        [Test]
        public void TCHomeLogout()
        {
            try
            {
                PageHome.OpenWebsite(driver);
                PageLogin.Login(driver);
                PageJewelry.SelectCategoryJewelry(driver);
                PageJewelry.ChangeView(driver);
                PageJewelry.AddProduct(session, driver);
                PageCart.CheckoutCart(session, driver);
                PageHome.LogoClickLogoutClick(driver);
            }
            catch (Exception ex) { Assert.Fail(ex.Message); }
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            session.Dispose();
            driver.Dispose();
        }
    }
}