using Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class Services : ListOfProducts , IServices
    {

        

        public void appInfo()
        {
            Console.WriteLine("Welcome to E-Shop APP");
            Console.WriteLine("________________________________");
            Console.WriteLine("1.See Vendors List");
            Console.WriteLine("________________________________");
            Console.WriteLine("2.Search by vendor name for their products");
            Console.WriteLine("_________________________________");
            Console.WriteLine("3.Search by part of name of Products");
            Console.WriteLine("_________________________________");
            Console.WriteLine("4.Sort products by asc or desc");
            Console.WriteLine("_________________________________");
            Console.WriteLine("5.Sort products by price");
            Console.WriteLine("_________________________________");
            Console.WriteLine("6.Make a order,preview order and add or remove content");
            Console.WriteLine("_________________________________");
            Console.WriteLine("10.To exit this app please enter exit");
            Console.WriteLine("_________________________________");
        }

        public void printVendors()
        {
            var vendorsItems = new VendorItems().VendorItemsList;

            Console.WriteLine("Vendors: ");
            Console.WriteLine("_________________________");
            foreach (var item in vendorsItems)
            {
                Console.WriteLine(item);
            }
        }

        public void printProductsByVendors()
        {
           
            Console.WriteLine("Select from SteelSeries,Razer,Corsair");
            Console.WriteLine("_______________________________________________________");
            var vendorBrands = Console.ReadLine();

            foreach (var product in productsItems[vendorBrands])
            {
                Console.WriteLine($"Name:{product.Name}\n Price:{product.Price}\n Product Code:{product.ProductCode}");
                Console.WriteLine("_______________________________________________");
            }
        }

        public void searchByProductName()
        {
           

            Console.WriteLine("Enter name of product to get that product");
            var inputProductName = Console.ReadLine();
            var searchProductName = productsItems.Select(c => c.Value.Where(y => y.Name == inputProductName));

            foreach (var product in searchProductName)
            {
                foreach (var product2 in product)
                {
                    Console.WriteLine(product2.Name);
                }
            }
        }

        public void ascDescProductItems()
        {
            Console.WriteLine("Write asc for sorted list by product name by ascending,or desc for oposite");

            

            var userProducts = Console.ReadLine();

            if (userProducts == "asc")
            {
                Console.WriteLine("Sorted list by product name Asc:");
                var sortByProductNameAsc = productsItems[userProducts].OrderBy(x => x.Name);

                foreach (var product in sortByProductNameAsc)
                {
                    Console.WriteLine($"Name:{product.Name}\n Price:{product.Price}\n Product Code:{product.ProductCode}");
                    Console.WriteLine("_______________________________________________");
                }

            }
            else if (userProducts == "desc")
            {
                Console.WriteLine("Sorted list by product name Desc:");

                var sortByProductNameDesc = productsItems[userProducts].OrderByDescending(x => x.Name);

                foreach (var product in sortByProductNameDesc)
                {
                    Console.WriteLine($"Name:{product.Name}\n Price:{product.Price}\n Product Code:{product.ProductCode}");
                    Console.WriteLine("_______________________________________________");
                }
            }
            else
            {
                Console.WriteLine("You enter invalid input");
            }
        }

        public void ascDescProductItemsByPrice()
        {
           

            Console.WriteLine("Write asc for sorted list by product price by ascending, or desc for oposite");
            var userProductsPrice = Console.ReadLine();
            if (userProductsPrice == "asc")
            {
                Console.WriteLine("Sorted list by product name Asc:");

                var sortByProductNameAsc = productsItems[userProductsPrice].OrderBy(x => x.Price);

                foreach (var product in sortByProductNameAsc)
                {
                    Console.WriteLine($"Name : {product.Name}\n price:{product.Price}\n Product code:{product.ProductCode}");
                    Console.WriteLine("______________________");
                }
            }
            if (userProductsPrice == "desc")
            {
                Console.WriteLine("Sorted list by product name Desc:");

                var sortByProductNameDesc = productsItems[userProductsPrice].OrderByDescending(x => x.Price);

                foreach (var product in sortByProductNameDesc)
                {
                    Console.WriteLine($"Name : {product.Name}\n price:{product.Price}\n Product code:{product.ProductCode}");
                    Console.WriteLine("______________________");
                }
            }
        }

        public void orders()
        {
           

            bool addOrderToCart = true;
            var userOrders = new List<OrderItem>();
            while (addOrderToCart)
            {
                Console.WriteLine("Enter product code");
                long productCode = long.Parse(Console.ReadLine());
                Console.WriteLine("Number of products");
                int quantity = Int32.Parse(Console.ReadLine());
                
               

                foreach (var item in productsItems)
                {
                    var product = item.Value.Find(c => c.ProductCode == productCode);
                    if(product != null)
                    {
                        double totalPrice = quantity * product.Price;
                        var order = new OrderItem(new ProductItem(
                            product.Name,
                            product.Price,
                            product.ProductCode),
                            quantity,totalPrice);
                        userOrders.Add(order);
                        
                            
                    }
                }
                Console.WriteLine("You can continue add orders or submit orders, enter add or submit");
                addOrderToCart = Console.ReadLine() == "add" ? true : false;
            }

            var userInput = Console.ReadLine();
            if(userInput == "submit")
            {
                foreach (var orderProducts in userOrders)
                {
                    Console.WriteLine($"Name: {orderProducts.Product.Name}\n price:{orderProducts.Product.Price}\n quantity: {orderProducts.Quantity}");
                    Console.WriteLine("_____________________________________");
                }
            }
            else if(userInput == "delete")
            {
                for (int i = 0; i < userOrders.Count; i++)
                {
                    Console.WriteLine($"{i}:Name:{userOrders[i].Product.Name}\n price:{userOrders[i].Product.Price}\n quantity:{userOrders[i].Quantity}");
                }
                Console.WriteLine("Select the row number of the product you want to remove");
                int removedProduct = int.Parse(Console.ReadLine());
                userOrders.RemoveAt(removedProduct);
                foreach (var item in userOrders)
                {
                    Console.WriteLine($"Name:{item.Product.Name}\n price:{item.Product.Price}\n quanity:{item.Quantity}");
                    Console.WriteLine("________________________");
                }
            }
            else if(userInput == "ship")
            {
                string msg = "You buy products with PayPal";
                string msgOne = "You buy products with CreditCard";
                PaymentEvent paymentEvent = new PaymentEvent();
                UserNotified userNotified = new UserNotified();
                paymentEvent.userNotifiedHandler += userNotified.MsgProcessed;
                var username = new User();
                Console.WriteLine(username.Name);
                for (int i = 0; i < userOrders.Count; i++)
                {
                    Console.WriteLine($"{i + 1}:Name:{userOrders[i].Product.Name} price:{userOrders[i].Product.Price} quanity:{userOrders[i].Quantity}");

                }
                double totalSum = userOrders.Sum(el => el.TotalPrice);
                Console.WriteLine("Total:" + totalSum);

                Console.WriteLine("You can continue to add orders or pay and ship current orders");
                Console.WriteLine("To continue adding orders enter add , to continue to paying and shipping orders enter submit");
                

                if (userInput == "submit")
                {
                    Console.WriteLine("Pay with credit card or paypal by entering credit or pay");

                    var creditCard = Console.ReadLine();
                    if (creditCard == "credit")
                    {
                        userNotified.MsgProcessed(msg);

                    }
                    if (creditCard == "pay")
                    {
                        userNotified.MsgProcessed(msgOne);

                    }
                    Console.WriteLine("If you are living in Skopje, Bitola, Ohrid, Stip you can get your products by entering your city name");

                    var city = Console.ReadLine();
                    if (city == "Skopje" || city == "Bitola" || city == "Ohrid" || city == "Stip")
                    {
                        Console.WriteLine("Please enter posta or delco to ship your orders");

                        var ship = Console.ReadLine();

                        if (ship == "posta")
                        {
                            Console.WriteLine("Your orders are shipped by posta....");
                        }
                        if (ship == "delco")
                        {
                            Console.WriteLine("Your orders are shipped by delco....");

                        }


                        Console.WriteLine("See your list of expensive orders above 50.000 or see your cheap orders under 50.000 by entering exp or cheap");
                        Console.WriteLine("Enter exp or cheap");
                        var cost = Console.ReadLine();
                        if (cost == "exp")
                        {
                            double fiveK = 50.000;
                            var totalSumExp = userOrders.Where(x => x.TotalPrice > fiveK);
                            foreach (var item in totalSumExp)
                            {
                                Console.WriteLine(item);
                            }

                        }
                        if (cost == "cheap")
                        {
                            double fiveK = 50.000;
                            var totalSumExp = userOrders.Where(x => x.TotalPrice < fiveK);
                            foreach (var item in totalSumExp)
                            {
                                Console.WriteLine(item);
                            }


                        }
                    }
                }


                else
                {
                    Console.WriteLine("We dont have service for shipping in your city yet or you dont choose right paying method");

                }
            }
            

        }

    }
}
