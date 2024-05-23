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
        private static readonly string _PAGE_TITLE = @"Demo Web Shop";
        private static readonly string _RETURNING_CUSTOMER = @"Returning Customer";
        private static readonly string _CHECKOUT = @"Checkout";

        public static string URL { get { return _URL; } }
        public static string LOGIN_PAGE_URL { get { return _LOGIN_PAGE_URL; } }
        public static string JEWELRY_PAGE_URL { get { return _JEWELRY_PAGE_URL; } }
        public static string CREATE_JEWELRY_PAGE_URL { get { return _CREATE_JEWELRY_PAGE_URL; } }
        public static string CART_PAGE_URL { get { return _CART_PAGE_URL; } }
        public static string CHECKOUT_PAGE_URL { get { return _CHECKOUT_PAGE_URL; } }
        public static string PAGE_TITLE { get { return _PAGE_TITLE; } }
        public static string RETURNING_CUSTOMER { get { return _RETURNING_CUSTOMER; } }
        public static string CHECKOUT { get { return _CHECKOUT; } }
    }
}