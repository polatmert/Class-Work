using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondCase_ShoppingCart
{
    class DeliveryCostCalculator 
    {
        public double costPerDelivery;
        public double costPerProduct;
        public double fixedCost;

        public DeliveryCostCalculator(double costPerDelivery,double costPerProduct,double fixedCost)
        {
           this.costPerDelivery = costPerProduct;
           this.costPerProduct = costPerProduct;
           this.fixedCost = fixedCost;
 
        }

        public double calculateFor(ShoppingCart cart)
        {
            var NumberOfDeliveries = calculateDeliveries(cart);
            var NumberOfProducts = calculateProducts(cart);

            double deliveryResult = ( costPerDelivery * NumberOfDeliveries ) 
                                     + (costPerProduct * NumberOfProducts) + fixedCost;
           
            return deliveryResult;
        }

        private int calculateDeliveries(ShoppingCart cart)
        {
            var deliveriesList = cart.items.Select(x => x.product.category.title).Distinct().ToList();
            if(deliveriesList != null && deliveriesList.Count > 0)
            {
                return deliveriesList.Count;
            }
            return 0;
        }

        private int calculateProducts(ShoppingCart cart)
        {
            var deliveriesList = cart.items.Select(x => x.product.title).Distinct().ToList();
            if (deliveriesList != null && deliveriesList.Count > 0)
            {
                return deliveriesList.Count;
            }
            return 0;
        }

    }
}
