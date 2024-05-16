using OpenQA.Selenium;
using SikuliSharp;

namespace Capstone_Project
{
    internal class PageCart
    {
        public static void CheckoutCart(ISikuliSession session, IWebDriver driver)
        {

            Constants.ClickOnAPattern(2, "1_clc_cntry_base.png", session);

            Constants.ClickOnAPattern(2, "2_slct_amrc_sm.png", session);

            Constants.ClickOnAPattern(2, "3_slct_zip_cd.png", session);
            session.Type("96799");

            Constants.ClickOnAPattern(2, "4_clc_agree.png", session);

            Constants.ClickOnAPattern(2, "5_clc_chck_out.png", session);

            if (driver.Url != Constants.CHECKOUT_PAGE_URL)
            {
                throw new Exception(
                    $"TEST CASE FAILD: " +
                    $"Checkout Page Not Displayed! " +
                    $"Actual: '{driver.Url}' " +
                    $"Expected: '{Constants.CHECKOUT_PAGE_URL}' "
                );
            }

            string element_text = Constants.FindElement(
                driver,
                @"body > div.master-wrapper-page > div.master-wrapper-content > div.master-wrapper-main > div > div > div.page-title > h1",
                "",
                true,
                false
            );

            if (element_text != Constants.CHECKOUT)
            {
                throw new Exception(
                    $"TEST CASE FAILD: " +
                    $"The correct login details are not showing! " +
                    $"Actual: '{element_text}' " +
                    $"Expected: '{Constants.CHECKOUT}' "
                );
            }

        }
    }
}
