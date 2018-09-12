using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitites
{
    public class VendorItems
    {
        public List<string> VendorItemsList;
        public VendorItems()
        {
            VendorItemsList = new List<string>();
            VendorItemsList.Add("SteelSeries");
            VendorItemsList.Add("Razer");
            VendorItemsList.Add("Corsair");

        }

       
    }
}
