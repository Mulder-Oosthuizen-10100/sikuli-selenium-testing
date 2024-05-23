# Capstone Project
This project incorporates C#, Selenium, and Sikuli to test 7 predefined test cases and report on their outcome.
The following website will be used to conduct the test cases.

<a href="https://demowebshop.tricentis.com/">
    <img src="img/readme/TestingWebsite.png" align="center"/>
</a>

## Table Of Content
- [How it Works](#how-it-works)
- [Usage](#usage)
- [Test Cases](#test-cases)
    - [Open Home Page](#open-home-page)
    - [Login to Website](#login-to-website)
    - [Select Product Category - Jewelry](#select-product-category---jewelry)
    - [Change Jewelry View](#change-jewelry-view)
    - [Select Create Your Own Jewelry](#select-create-your-own-jewelry)
    - [Checkout Cart](#checkout-cart)
    - [Go to Home Page and Logout](#go-to-home-page-and-logout)
- [Reports](#reports)
- [Configuration](#configuration)

## How It Works
1. The OneTimeSetup function is called and the session, driver, and report objects are created.
2. The test cases are executed/tested one by one and one after the other.
3. If a test cases passes it will be reported as a passed test.
4. If a test cases fails it will be reported as a failed test case and an exception message will be attached.
5. The OneTimeTearDown function is called and the session, driver and report objects are destroyed.

## Usage
Use the configuration file to configure your username and password. Once configured you may run all the test cases. Because this is automated software, there is nothing much for you to do other than configuration.

## Test Cases
Here is the list of all 7 test cases, each with more detail on what the test case does.

### Open Home Page
This test case will open the test website and verify the correct website is opened by validating the page title.

### Login to Website
This test case will click the login link and verify the correct page is opened. Once the page is verified the username and password will be entered and the user will be logged in. Once logged in the username of the user will be verified.

### Select Product Category - Jewelry
This test case will click on the jewelry category link and verify that the correct page is opened by validating the page url.

### Change Jewelry View
This test case will change the grid view of all the jewelry products to a list view of all the products.

### Select Create Your Own Jewelry
This test case will click on the create your own product in the product list. Once the page opens the desired product information is entered and the product is added to the cart by clicking on the add to cart button.

### Checkout Cart
This test case will enter the postal information and click on the checkout button. 

### Go to Home Page and Logout
This test case will click on the page logo to go to the home page and then click on the logout link.

## Reports
The report, after all the test cases have completed, is a basic report that shows the outcome of all the test cases. It will show if a test case passed or failed and if a test case failed it will show the error message.

## Configuration
1. User name: ``` private static readonly string _USERNAME = @"addyourusernamehere"; ```
2. Password: ``` private static readonly string _PASSWORD = @"addyourpasswordhere"; ```
