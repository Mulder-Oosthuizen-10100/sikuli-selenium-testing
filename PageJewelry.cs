using OpenQA.Selenium;
using SikuliSharp;

namespace Capstone_Project
{
    internal class PageJewelry
    {
        public static void SelectCategoryJewelry(IWebDriver driver)
        {
            GlobalFunctions.FindElement(
                driver, 
                @"body > div.master-wrapper-page > div.master-wrapper-content > div.master-wrapper-main > div.leftside-3 > div.block.block-category-navigation > div.listbox > ul > li:nth-child(6) > a",
                "",
                false,
                true
            );

            if (driver.Url != Constants.JEWELRY_PAGE_URL)
            {
                throw new Exception(
                    $"TEST CASE FAILD: " +
                    $"Jewelry Page Not Displayed! " +
                    $"Actual: '{driver.Url}' " +
                    $"Expected: '{Constants.JEWELRY_PAGE_URL}' "
                );
            }
        }

        public static void ChangeView(IWebDriver driver)
        {
            GlobalFunctions.PopulateSelect(driver, "products-viewmode", "List", false);
        }

        public static void AddProduct(ISikuliSession session, IWebDriver driver)
        {

            GlobalFunctions.ClickOnAPattern(1, "1_create_your_own.png", session);
            
            if (driver.Url != Constants.CREATE_JEWELRY_PAGE_URL)
            {
                throw new Exception(
                    $"TEST CASE FAILD: " +
                    $"Create Your Own Jewelry Page Not Displayed! " +
                    $"Actual: '{driver.Url}' " +
                    $"Expected: '{Constants.CREATE_JEWELRY_PAGE_URL}' "
                );
            }

            GlobalFunctions.ClickOnAPattern(1, "2_clc_mtrl_base.png", session);

            GlobalFunctions.ClickOnAPattern(1, "3_slct_mtrl_gld_1.png", session);

            GlobalFunctions.ClickOnAPattern(1, "4_clc_lngth.png", session);
            session.Type("30");

            GlobalFunctions.ClickOnAPattern(1, "5_slct_pndnt_hrt.png", session);

            GlobalFunctions.ClickOnAPattern(1, "6_clc_qty.png", session);
            GlobalFunctions.SendKeystroke(WindowsInput.Native.VirtualKeyCode.BACK);
            session.Type("2");

            GlobalFunctions.ClickOnAPattern(1, "7_clc_add_to_crt.png", session);

            GlobalFunctions.FindElement(
                driver,
                @"#topcartlink > a > span.cart-label",
                "",
                false,
                true
            );

            if (driver.Url != Constants.CART_PAGE_URL)
            {
                throw new Exception(
                    $"TEST CASE FAILD: " +
                    $"Cart Page Not Displayed! " +
                    $"Actual: '{driver.Url}' " +
                    $"Expected: '{Constants.CART_PAGE_URL}' "
                );
            }
        }
    }
}
