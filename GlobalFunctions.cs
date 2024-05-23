using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SikuliSharp;
using WindowsInput;

namespace Capstone_Project
{
    internal class GlobalFunctions
    {
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
                    IPattern pattern = Patterns.FromFile(BasePath('P', path));
                    session.Click(pattern);
                }
                else if (test_case == 2)
                {
                    IPattern pattern = Patterns.FromFile(BasePath('C', path));
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

        public static string BasePath(char choice, string path)
        {
            string image_path = "";
            try
            {
                image_path = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())));
                if (image_path == null)
                {
                    throw new Exception(
                        $"TEST CASE FAILD: " +
                        $"Images Base Path could not be resolved!"
                    );
                }
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"TEST CASE FAILD: " +
                    $"An Unknown Exception Occurred! " +
                    $"Exception Message: '{ex.Message}' "
                );
            }

            if (choice == 'P')
            {
                return image_path += @"\img\add_prd\" + path;
            }
            else if (choice == 'C')
            {
                return image_path += @"\img\chck_out\" + path;
            }
            else
            {
                return "";
                throw new Exception(
                    "Function 'BasePath' parameter 'choice' does not match 'P' -> Product or 'C' -> Checkout!"
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
