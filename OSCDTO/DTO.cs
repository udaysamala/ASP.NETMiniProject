using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSCDTO
{
    public class Customer
    {
        
        public string Password
        {
            get { return Password; }
            set { Password = value; }
        }

        public string Username { get => Username; set => Username = value; }
       
        public string Mobile { get => Mobile; set => Mobile = value; }
        public string Name { get => Name; set => Name = value; }
    }
    public class Admin{
        string user ="admin";
        string pass = "admin";

        public string User { get => user; set => user = value; }
        public string Pass { get => pass; set => pass = value; }
    }
    public class Product
    {
        string sno;
        string productId;
        string title;
        string summary;
        string price;
        string discount;
        string quantity;
        string deleteproduct;

        public string Sno { get => sno; set => sno = value; }
        public string ProductId { get => productId; set => productId = value; }
        public string Title { get => title; set => title = value; }
        public string Summary { get => summary; set => summary = value; }
        public string Price { get => price; set => price = value; }
        public string Discount { get => discount; set => discount = value; }
        public string Quantity { get => quantity; set => quantity = value; }
        public string Deleteproduct { get => deleteproduct; set => deleteproduct = value; }
    }
    public class ADDCart
    {
        string check;
        string sno;
        string username;
        string productid;
        string productname;
        string quantity;
        string price;

        public string Sno { get => sno; set => sno = value; }
        public string Username { get => username; set => username = value; }
        public string Productid { get => productid; set => productid = value; }
        public string Productname { get => productname; set => productname = value; }
        public string Quantity { get => quantity; set => quantity = value; }
        public string Price { get => price; set => price = value; }
        public string Check { get => check; set => check = value; }
    }

}
