using SecondCase_ShoppingCart.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondCase_ShoppingCart
{
    class ShoppingCart
    {
        public List<ShoppingCartItem> items;

        private double totalAmount;
        private double subTotalAmount;
        private double discount;
        private double totalAmountAfterDiscount;
        private double couponDiscount;
        private double totalAmountAfterCoupon;
        private double deliveryCost;

        public ShoppingCart()
        {
            items = new List<ShoppingCartItem>();
            totalAmount = 0;
            subTotalAmount = 0;
            discount=0;
            totalAmountAfterDiscount = 0;
            couponDiscount = 0;
            totalAmountAfterCoupon = 0;
            deliveryCost = 0;
        }

        public void addItem(Product product, int quantity)
        {
            if(product == null )
            {
                throw new ArgumentNullException("product");
            }

            ShoppingCartItem cartItem = new ShoppingCartItem()
            {
                product = product,
                quantity = quantity
            };
            totalAmount += product.price * quantity;
            subTotalAmount +=  product.price * quantity;

            items.Add(cartItem);
        }

        public void applyDiscounts(double disc1=0, double disc2=0, double disc3=0)
        {

            if(disc1 > disc2 && disc1 > disc3 ) 
            {
                discount += disc1;
            }
            else if (disc2 > disc1 && disc2 > disc3)
            {
                discount += disc2;
            }else
            {
                discount += disc3;
            }

            totalAmountAfterDiscount = totalAmount - discount;
        }

        public void applyCoupon(Coupon coupon)
        {
            if(coupon != null)
            {
                if (this.totalAmount > coupon.minAmount)
                {
                    if (coupon.disountTye == DiscountType.Rate)
                    {
                        couponDiscount += (totalAmount * (coupon.couponValue) / 100);
                    }
                    else if (coupon.disountTye == DiscountType.Amount)
                    {
                        couponDiscount += coupon.couponValue;

                    }
                }
            }
            totalAmountAfterCoupon = totalAmountAfterDiscount - couponDiscount;
        }

        public double getCouponDiscount()
        {
            return totalAmountAfterDiscount - totalAmountAfterCoupon;
        }

        public double getCampaignDiscount(Campaign campaign)
        {
            double cartTotalAmonuntBeforeDiscount = this.items.Sum(x => x.product.price);
            double maxDiscount = 0;
            double tempDiscountAmount = 0;

            foreach (var item in this.items)
            {
                if (item.product.category.title.Equals(campaign.category.title) && item.quantity >= campaign.quantity)
                {
                    if (campaign.disountTye == DiscountType.Rate)
                    {
                        tempDiscountAmount = cartTotalAmonuntBeforeDiscount * (campaign.discountValue) / 100;
                    }
                    else if (campaign.disountTye == DiscountType.Amount)
                    {
                        tempDiscountAmount = cartTotalAmonuntBeforeDiscount - campaign.discountValue;
                    }

                    if (tempDiscountAmount > maxDiscount)
                        maxDiscount = tempDiscountAmount;
                }

            }

            return maxDiscount;
        }

        public double getTotalAmountAfterDiscounts()
        {
            subTotalAmount = totalAmount - discount - couponDiscount;
            return subTotalAmount;
        }

        public double getDeliveryCost()
        {
            DeliveryCostCalculator delCostCal = new DeliveryCostCalculator(Constants.CostPerDelivery, Constants.CostPerProduct, Constants.DeliveryFixedCost);
            deliveryCost = delCostCal.calculateFor(this);
            return deliveryCost;
        }

        public List<string> print()
        {
            List<string> logMesssages = new List<string>();
            logMesssages.Add("FINAL");

            var groupedItem = this.items.OrderBy(x => x.product.category.title);
            
            foreach(var item in groupedItem)
            {
                var catName = item.product.category.title;
                var proName = item.product.title;
                var quantity = item.quantity;
                var unitprice = item.product.price;

                logMesssages.Add("category name: "+ catName +" product name: "+proName+" quantity:"+quantity+" unit price: "+PriceFormatter.DoubleToString(unitprice));
            }

            logMesssages.Add("total price : " + PriceFormatter.DoubleToString(totalAmount));
            logMesssages.Add("total discount : " + PriceFormatter.DoubleToString(totalAmount - subTotalAmount));
            logMesssages.Add("delivery: " + PriceFormatter.DoubleToString(deliveryCost));
            logMesssages.Add("final price: " + PriceFormatter.DoubleToString((subTotalAmount + deliveryCost)));

            return logMesssages;
        }
    }
}
