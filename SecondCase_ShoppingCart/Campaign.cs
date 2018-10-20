using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecondCase_ShoppingCart.Enum;

namespace SecondCase_ShoppingCart
{
    class Campaign
    {
        public Category category;
        public int discountValue;
        public int quantity;
        public DiscountType disountTye;

        public Campaign(Category category, int discountValue, int quantity, DiscountType disountTye)
       {
           this.category = category;
           this.discountValue = discountValue;
           this.quantity = quantity;
           this.disountTye = disountTye;
       }

    }
}
