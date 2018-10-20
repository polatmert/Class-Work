using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondCase_ShoppingCart
{
    class Category
    {
        public string title;

        public Category parentCategory;


        public Category(string categoryName)
        {
            if (categoryName == null)
                throw new ArgumentNullException("categoryName");

            this.title = categoryName;
            
        }

        public Category(string categoryName , Category parentCategory)
        {
            if (categoryName == null)
                throw new ArgumentNullException("categoryName");

            this.title = categoryName;
            this.parentCategory = parentCategory;
        }

    }
}
