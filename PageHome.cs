using OpenQA.Selenium;

namespace Capstone_Project
{
    internal class PageHome
    {
        public static void OpenWebsite(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(Constants.URL);

            if (driver.Title != Constants.PAGE_TITLE)
            {
                throw new Exception(
                    $"TEST CASE FAILD: " +
                    $"Page Title is not correct! " +
                    $"Actual: '{driver.Title}' " +
                    $"Expected: '{Constants.PAGE_TITLE}' "
                );
            }
        }

        public static void LogoClickLogoutClick(IWebDriver driver)
        {
            Constants.FindElement(
                driver,
                @"body > div.master-wrapper-page > div.master-wrapper-content > div.header > div.header-logo > a > img",
                "",
                false,
                true
            );

            Thread.Sleep(500);

            Constants.FindElement(
                driver,
                @"body > div.master-wrapper-page > div.master-wrapper-content > div.header > div.header-links-wrapper > div.header-links > ul > li:nth-child(2) > a",
                "",
                false,
                true
            );

            Thread.Sleep(2000);
        }
    }
}
