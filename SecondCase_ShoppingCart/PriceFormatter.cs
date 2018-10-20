using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondCase_ShoppingCart
{
    static class PriceFormatter
    {
        public  static string DoubleToString(double price )
        {
            string formattedPrice = String.Format("{0:C}", price);
            
            return formattedPrice;
        }
    }
}
