using Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Services
{
    public class EShopApp
    {
        public static void startApp()
        {
            var services = new Services();

            

            Console.WriteLine("Enter Username");
            var username = new User(Console.ReadLine());
            services.appInfo();
            bool productsShop = true;
            while (productsShop)
            {
                var getUserInput = 0;
                bool isValidInput = Int32.TryParse(Console.ReadLine(), out getUserInput);
                if(isValidInput == false || getUserInput < 1 || getUserInput >8)
                {
                    Console.WriteLine("Your input is invalid. Please try aghain.");
                }
                switch(getUserInput)
                {
                    case 1:
                        services.printVendors();
                        break;
                    case 2:
                        services.printProductsByVendors();
                        break;
                    case 3:
                        services.searchByProductName();
                        break;
                    case 4:
                        services.ascDescProductItems();
                        break;
                    case 5:
                        services.ascDescProductItemsByPrice();
                        break;
                    case 6:
                        services.orders();
                        break;
                }
               
            }
            
        }
    }
}
