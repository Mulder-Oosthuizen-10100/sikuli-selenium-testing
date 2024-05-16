using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SikuliSharp;
using WindowsInput;

namespace Capstone_Project
{
    internal class Constants
    {
        private static readonly string _URL = @"https://demowebshop.tricentis.com/";
        private static readonly string _LOGIN_PAGE_URL = @"https://demowebshop.tricentis.com/login";
        private static readonly string _JEWELRY_PAGE_URL = @"https://demowebshop.tricentis.com/jewelry";
        private static readonly string _CREATE_JEWELRY_PAGE_URL = @"https://demowebshop.tricentis.com/create-it-yourself-jewelry";
        private static readonly string _CART_PAGE_URL = @"https://demowebshop.tricentis.com/cart";
        private static readonly string _CHECKOUT_PAGE_URL = @"https://demowebshop.tricentis.com/onepagecheckout";
        private static readonly string _USERNAME = @"reg@reg.com";
        private static readonly string _PASSWORD = @"TESTING";
        private static readonly string _PAGE_TITLE = @"Demo Web Shop";
        private static readonly string _RETURNING_CUSTOMER = @"Returning Customer";
        private static readonly string _CHECKOUT = @"Checkout";
        private static readonly string _ADD_PRODUCT_BASE_PATH = @"C:\Training\Capstone-Project\img\add_prd\";
        private static readonly string _CHECKOUT_BASE_PATH = @"C:\Training\Capstone-Project\img\chck_out\";

        public static string URL { get { return _URL; } }
        public static string LOGIN_PAGE_URL { get { return _LOGIN_PAGE_URL; } }
        public static string JEWELRY_PAGE_URL { get { return _JEWELRY_PAGE_URL; } }
        public static string CREATE_JEWELRY_PAGE_URL { get { return _CREATE_JEWELRY_PAGE_URL; } }
        public static string CART_PAGE_URL { get { return _CART_PAGE_URL; } }
        public static string CHECKOUT_PAGE_URL { get { return _CHECKOUT_PAGE_URL; } }
        public static string USERNAME { get { return _USERNAME; } }
        public static string PASSWORD { get { return _PASSWORD; } }
        public static string PAGE_TITLE { get { return _PAGE_TITLE; } }
        public static string RETURNING_CUSTOMER { get { return _RETURNING_CUSTOMER; } }
        public static string CHECKOUT { get { return _CHECKOUT; } }


        public static string FindElement(IWebDriver driver, string element_class, string element_keys, bool Text, bool Click)
        {
            try
            {
                IWebElement an_element = driver.FindElement(By.CssSelector(element_class));

                if (Click && !Text)
                {
                    an_element.Click();
                    return "";
                }
                else if (!Click && Text)
                {
                    return an_element.Text;
                }
                else if (!Click && !Text)
                {
                    an_element.SendKeys(element_keys);
                    return "";
                }
                else
                {
                    throw new Exception(
                        "Function 'FindElement' Click and Text Combination are not correct!"
                    );
                }
            }
            catch (NoSuchElementException ex)
            {
                throw new Exception(
                    $"TEST CASE FAILD: " +
                    $"Class Element not Found using CssSelector! " +
                    $"Exception Message: '{ex.Message}'"
                );
            }
            catch (ElementNotVisibleException ex)
            {
                throw new Exception(
                    $"TEST CASE FAILD: " +
                    $"Class Element not Visible using CssSelector! " +
                    $"Exception Message: '{ex.Message}'"
                );
            }
            catch (StaleElementReferenceException ex)
            {
                throw new Exception(
                    $"TEST CASE FAILD: " +
                    $"Exception Message: '{ex.Message}'"
                );
            }
        }

        public static void PopulateSelect(IWebDriver driver, string SelectName, string SelectOption, bool SelectByValue = true)
        {
            try
            {
                SelectElement DropDown = new SelectElement(driver.FindElement(By.Name(SelectName)));
                if (SelectByValue)
                {
                    DropDown.SelectByValue(SelectOption);
                }
                else
                {
                    DropDown.SelectByText(SelectOption);
                }
            }
            catch (NoSuchElementException ex)
            {
                throw new Exception(
                    $"TEST CASE FAILD: " +
                    $"Element not Found using Name! " +
                    $"Exception Message: '{ex.Message}' "
                );
            }
        }

        public static void ClickOnAPattern(int test_case, string path, ISikuliSession session)
        {
            try
            {
                Thread.Sleep(500);

                if (test_case == 1)
                {
                    IPattern pattern = Patterns.FromFile(_ADD_PRODUCT_BASE_PATH + path);
                    session.Click(pattern);
                }
                else if (test_case == 2)
                {
                    IPattern pattern = Patterns.FromFile(_CHECKOUT_BASE_PATH + path);
                    session.Click(pattern);
                }
            }
            catch (FileNotFoundException ex)
            {
                throw new Exception(
                    $"TEST CASE FAILD: " +
                    $"Image not found! " +
                    $"Exception Message: '{ex.Message}' "
                );
            }
            catch (SikuliFindFailedException ex)
            {
                throw new Exception(
                    $"TEST CASE FAILD: " +
                    $"Pattern not found! " +
                    $"Exception Message: '{ex.Message}' "
                );
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"TEST CASE FAILD: " +
                    $"An Unknown Exception Occurred! " +
                    $"Exception Message: '{ex.Message}' "
                );
            }
        }

        public static void SendKeystroke(WindowsInput.Native.VirtualKeyCode key)
        {
            InputSimulator sim = new InputSimulator();
            sim.Keyboard.KeyPress(key);
        }

    }
}