using SecondCase_ShoppingCart.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace SecondCase_ShoppingCart
{
    public partial class Form1 : Form
    {
        ShoppingCart cart;
        List<Category> categories;
        List<Product> products;
        List<Campaign> campaigns;
        List<Coupon> coupons;

        public Form1()
        {
            InitializeComponent();
            #region CART
            cart = new ShoppingCart();
            #endregion
           
            #region Create Dummy Data
            CreateDummyData();
            #endregion
        }


        private void run_Click(object sender, EventArgs e)
        {
            cart.addItem(products[0], 3);
            createLog(products[0].title + " added to shopping cart " + 3 + " piece");

            cart.addItem(products[3], 5);
            createLog(products[3].title + " added to shopping cart " + 5 + " piece");

            cart.addItem(products[4], 1);
            createLog(products[4].title + " added to shopping cart " + 1 + " piece");

            var discount1 = cart.getCampaignDiscount(campaigns[0]);
            var discount2 = cart.getCampaignDiscount(campaigns[1]);
            var discount3 = cart.getCampaignDiscount(campaigns[2]);

            cart.applyDiscounts(discount1, discount2, discount3);
            
            cart.applyCoupon(coupons[0]);
            
            cart.getTotalAmountAfterDiscounts();
            
            var delCost = cart.getDeliveryCost();

            var logs = cart.print();

            foreach(var msg in logs)
            {
                createLog(msg);
            }

            SendMail();
        }

        public void CreateDummyData()
        {

            #region CATEGORY
            categories = new List<Category>(){
                new Category("Phone"),
                new Category("Book"),
                new Category("Computer")
            };
            

            #endregion

            #region PRODUCT
            products = new List<Product>(){
                new Product("iphone 7s", 7050.0, categories[0]),
                new Product("Samsung s9",5555, categories[0]),
                new Product("Hayvan Çiftliği",25.0, categories[1]),
                new Product("Nutuk",29.99, categories[1]),
                new Product("MacBook pro",10500.0, categories[2]),
                new Product("Hp Elite 5",2555.0, categories[2]),
            };
            #endregion

            #region CAMPAIGN
            campaigns = new List<Campaign>(){
                new Campaign(categories[0], 20, 3, DiscountType.Rate),
                new Campaign(categories[0], 50, 5, DiscountType.Rate),
                new Campaign(categories[1], 50, 5, DiscountType.Amount)
            };
            #endregion

            #region COUPON
            coupons = new List<Coupon>(){
                new Coupon(100,10,DiscountType.Rate),
                new Coupon(5000,10,DiscountType.Rate),
                new Coupon(100,20,DiscountType.Amount),
            };
            #endregion


        }

        public void createLog(string message)
        {
            dataGridView1.Rows.Add(message);
        }

        public void SendMail()
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("*************");
            mail.To.Add("*******************");
            mail.Subject = "*****";
            mail.Body = "********";
            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new NetworkCredential("****", "****");
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }
    }
}
