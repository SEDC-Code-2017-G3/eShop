using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IServices
    {
        void appInfo();
        void printVendors();
        void printProductsByVendors();
        void searchByProductName();
        void ascDescProductItems();
        void ascDescProductItemsByPrice();
        void orders();
        
        
    }
}
