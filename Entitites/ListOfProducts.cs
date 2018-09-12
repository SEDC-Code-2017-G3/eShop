using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitites
{
    public class ListOfProducts
    {
        

        public ListOfProducts()
        {
            var productsItems = new Dictionary<string, List<ProductItem>>();
            productsItems.Add("SteelSeries", new List<ProductItem>()
            {
                new ProductItem("SteelSeries",30000,001),
                new ProductItem("SteelSeries",35000,002),
                new ProductItem("SteelSeries",25000,003),
            });
            productsItems.Add("Razer", new List<ProductItem>()
            {
                new ProductItem("Razer",50000,004),
                new ProductItem("Razer",70000,005),
                new ProductItem("Razer",100000,006),
            });
            productsItems.Add("Corsair", new List<ProductItem>()
            {
                new ProductItem("Corsair",180000,007),
                new ProductItem("Corsair",550000,008),
                new ProductItem("Corsair",75000,009),
            });
        }
        public Dictionary<string, List<ProductItem>> productsItems { get; set; }


    }
}
