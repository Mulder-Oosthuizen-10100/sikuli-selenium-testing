using OpenQA.Selenium;

namespace Capstone_Project
{
    internal class PageLogin
    {
        public static void Login(IWebDriver driver)
        {
            Thread.Sleep(1000);
            _ClickLoginLink(driver);
            Thread.Sleep(500);
            _VerifyLoginPage(driver);
            _LoginToAccount(driver);
            Thread.Sleep(1000);
            _VerifySuccessfulLogin(driver);
            Thread.Sleep(1000);
        }

        public static void _ClickLoginLink(IWebDriver driver)
        {
            GlobalFunctions.FindElement(driver, @".ico-login", "", false, true);

            if (driver.Url != Constants.LOGIN_PAGE_URL)
            {
                throw new Exception(
                    $"TEST CASE FAILD: " +
                    $"Login Page Not Displayed! " +
                    $"Actual: '{driver.Url}' " +
                    $"Expected: '{Constants.LOGIN_PAGE_URL}' "
                );
            }
        }

        public static void _VerifyLoginPage(IWebDriver driver)
        {

            string element_text = GlobalFunctions.FindElement(
                driver,
                @"body > div.master-wrapper-page > div.master-wrapper-content > div.master-wrapper-main > div.center-2 > div > div.page-body > div.customer-blocks > div.returning-wrapper > div.title > strong",
                "",
                true,
                false
            );

            if (element_text != Constants.RETURNING_CUSTOMER)
            {
                throw new Exception(
                    $"TEST CASE FAILD: " +
                    $"The correct login details are not showing! " +
                    $"Actual: '{element_text}' " +
                    $"Expected: '{Constants.RETURNING_CUSTOMER}' "
                );
            }
        }

        public static void _LoginToAccount(IWebDriver driver)
        {
            GlobalFunctions.FindElement(driver, "#Email", Constants.USERNAME, false, false);
            GlobalFunctions.FindElement(driver, "#Password", Constants.PASSWORD, false, false);
            GlobalFunctions.FindElement(
                driver, 
                "body > div.master-wrapper-page > div.master-wrapper-content > div.master-wrapper-main > div.center-2 > div > div.page-body > div.customer-blocks > div.returning-wrapper > div.form-fields > form > div.buttons > input",
                "",
                false,
                true
            );
        }

        public static void _VerifySuccessfulLogin(IWebDriver driver)
        {
            string element_text = GlobalFunctions.FindElement(
                driver,
                @"body > div.master-wrapper-page > div.master-wrapper-content > div.header > div.header-links-wrapper > div.header-links > ul > li:nth-child(1) > a",
                "",
                true,
                false
            );

            if (element_text != Constants.USERNAME)
            {
                throw new Exception(
                    $"TEST CASE FAILD: " +
                    $"The correct login details are not showing! " +
                    $"Actual: '{element_text}' " +
                    $"Expected: '{Constants.USERNAME}' "
                );
            }
        }
    }
}
