using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecondCase_ShoppingCart.Enum;

namespace SecondCase_ShoppingCart
{
    class Coupon
    {
        public double minAmount;
        public double couponValue;
        public DiscountType disountTye;

        public Coupon(double minAmount, double couponValue, DiscountType disountTye)
        {
           this.minAmount = minAmount;
           this.couponValue = couponValue;
           this.disountTye = disountTye;
        }
    }
}
