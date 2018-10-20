using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondCase_ShoppingCart
{
    class Product
    {
        public string title;

        public double price;

        public Category category;

        public Product(string title, double price, Category category)
        {
            this.title = title;
            this.price = price;
            this.category = category;
        }

    }
}
