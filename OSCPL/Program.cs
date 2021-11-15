using OSCBL;
using OSCDAL;
using OSCDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSCPL
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Boolean n = true;
                DAL dal = new DAL();

                BL bl = new BL();
                while (n)
                {

                    Console.WriteLine(" 1. Customer Login\n 2. Admin Login\n 3. Exit");
                    Console.Write("Enter Your Choice : ");
                    int a = Convert.ToInt32(Console.ReadLine());
                    switch (a)
                    {
                        case 1:
                            Console.WriteLine("Enter the username :");
                            string username = Console.ReadLine();
                            Console.WriteLine("Enter the password :");
                            string password = Orb.App.Console.ReadPassword();
                            Console.WriteLine(" 1. Login\n 2. SiginUp");
                            Console.Write("Enter Your Choice : ");
                            int status = Convert.ToInt32(Console.ReadLine());
                            Customer dto = new Customer();
                            dto.Username = username;
                            dto.Password = password;

                            if (status == 1)
                            {
                                int result1 = bl.CheckLogin(dto);
                                if (result1 == 1)
                                {
                                    Console.WriteLine("Welcome " + username);
                                    Console.WriteLine(" 1. View Products\n 2. Add To Cart\n 3. View Cart\n 4. Delete From Cart\n 5. Exit");
                                    Console.Write("Enter Your Choice : ");
                                    int num = Convert.ToInt32(Console.ReadLine());
                                    if (num == 1)
                                    {
                                        List<Product> lstFinalResult = bl.GetAllProductDetails();
                                        Console.WriteLine("--Sno--|--ProductTitle--|--Product Quantity--|--Product Price--");
                                        foreach (var pro in lstFinalResult)
                                        {
                                            Console.WriteLine(pro.Sno + "    |    " + pro.Title + "     |    " + pro.Quantity + "     |     " + pro.Price);
                                        }

                                    }
                                    if (num == 2)
                                    {
                                        Console.WriteLine("Enter SNo. or Product Name :");
                                        string snpn = Console.ReadLine();
                                        Console.WriteLine("Enter Quantity Required :");
                                        string qreq = Console.ReadLine();

                                        ADDCart crdto = new ADDCart();
                                        crdto.Username = username;
                                        crdto.Check = snpn;
                                        crdto.Quantity = qreq;
                                        

                                        int result2 = bl.InsertintoCart(crdto);
                                        if (result2 == 1)
                                        {
                                            Console.WriteLine("Product Inserted Successfull! You Can View Cart");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Product NotInserted! Check Quantity");

                                        }

                                    }
                                    if (num == 3)
                                    {
                                        dto.Username = username;
                                        
                                        List<ADDCart> lstFinalResult = bl.FetchCart();
                                        Console.WriteLine("--ProductName--|--Product Quantity--|--Product Price--");
                                        foreach (var cart in lstFinalResult)
                                        {
                                            Console.WriteLine(cart.Productname + "|" + cart.Quantity + "|" + cart.Price );
                                        }


                                    }
                                    if (num == 4)
                                    {
                                        Console.WriteLine("UnderProcess");

                                    }
                                    else
                                    {
                                        n = false;
                                        Console.WriteLine("ThankYou!");
                                    }



                                }
                                else
                                {
                                    Console.WriteLine("No data found! please signup");

                                }
                            }
                            if (status == 2)
                            {
                                Console.WriteLine("Enter Name :");
                                string name = Console.ReadLine();
                                Console.WriteLine("Enter Mobile No. :");
                                string mobile = Console.ReadLine();
                                dto.Name = name;
                                dto.Mobile = mobile;
                                int result1 = bl.regsignup(dto);
                                if (result1 == 1)
                                {
                                    Console.WriteLine("Registration Successfull! You can Login Now");
                                }
                                else
                                {
                                    Console.WriteLine("Registartion Unsuccessfull");

                                }

                               

                            }

                            break;
                        case 2:
                            Console.WriteLine("Enter the username :");
                            string user = Console.ReadLine();
                            Console.WriteLine("Enter the password :");
                            string pass = Orb.App.Console.ReadPassword();


                            Admin dto1 = new Admin();
                            dto1.User = user;
                            dto1.Pass = pass;
                            int result = bl.checkadminlogin(dto1);
                            if (result == 1)
                            {
                                Console.WriteLine("Welcome "+user);
                                Console.WriteLine(" 1. Add Product\n 2. View Products\n 3. Delete Products\n 4. Exit");
                                Console.Write("Enter Your Choice : ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (num == 1)
                                {
                                    Console.WriteLine("Enter ProductID :");
                                    string productId = Console.ReadLine();
                                    Console.WriteLine("Enter ProductName :");
                                    string title = Console.ReadLine();
                                    Console.WriteLine("Enter Product Summary :");
                                    string summary = Console.ReadLine();
                                    Console.WriteLine("Enter Productprice :");
                                    string price = Console.ReadLine();
                                    Console.WriteLine("Enter ProductDiscount :");
                                    string discount = Console.ReadLine();
                                    Console.WriteLine("Enter ProductQuantity :");
                                    string quantity = Console.ReadLine();
                                    Product dto2 = new Product();
                                    dto2.ProductId = productId;
                                    dto2.Title = title;
                                    dto2.Summary = summary;
                                    dto2.Price = price;
                                    dto2.Discount = discount;
                                    dto2.Quantity = quantity;
                                    
                                    int result2 = bl.InsertintoProductTable(dto2);
                                    if (result2 == 1)
                                    {
                                        Console.WriteLine("Product Inserted Successfull! You Can View Product");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Product NotInserted! Unsuccessfull");

                                    }

                                }
                                if (num == 2)
                                {
                                    List<Product> lstFinalResult = bl.AdminProductDetails();
                                    Console.WriteLine("--Sno--|--ProductTitle--|--Product Quantity--|--Product Price--");
                                    foreach (var pro in lstFinalResult)
                                    {
                                        Console.WriteLine(pro.Sno + "    |    " + pro.Title + "   |   " + pro.Quantity + "    |   " + pro.Price);
                                    }

                                }
                                if (num == 3)
                                {
                                    List<Product> lstFinalResult = bl.AdminProductDetails();
                                    Console.WriteLine("--ProductID--|--ProductTitle--|--Product Quantity--|--Product Price--");
                                    foreach (var pro in lstFinalResult)
                                    {
                                        Console.WriteLine(pro.ProductId + "|" + pro.Title + "|" + pro.Quantity + "|" + pro.Price);
                                    }
                                    Console.WriteLine("Enter Product Id To Delete :");
                                    string deletepro = Console.ReadLine();
                                    Product dto3 = new Product();
                                    dto3.Deleteproduct = deletepro;
                                    int result3 = bl.DeleteProductItem(dto3);
                                    if (result3 == 1)
                                    {
                                        Console.WriteLine("Product Deleted Successfull! You Can View Product");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Product NotDeleted! Unsuccessfull");

                                    }
                                }
                                else
                                {
                                    n = false;
                                    Console.WriteLine("ThankYou!");
                                }
                            }

                            else
                            {
                                Console.WriteLine("Invalid Login credentials!");


                            }


                            break;
                        default:
                            n = false;
                            break;

                    }

                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }


    namespace Orb.App
    {
        /// <summary>
        /// Adds some nice help to the console. Static extension methods don't exist (probably for a good reason) so the next best thing is congruent naming.
        /// </summary>
        static public class Console
        {
            /// <summary>
            /// Like System.Console.ReadLine(), only with a mask.
            /// </summary>
            /// <param name="mask">a <c>char</c> representing your choice of console mask</param>
            /// <returns>the string the user typed in </returns>
            public static string ReadPassword(char mask)
            {
                const int ENTER = 13, BACKSP = 8, CTRLBACKSP = 127;
                int[] FILTERED = { 0, 27, 9, 10 /*, 32 space, if you care */ }; // const

                var pass = new Stack<char>();
                char chr = (char)0;

                while ((chr = System.Console.ReadKey(true).KeyChar) != ENTER)
                {
                    if (chr == BACKSP)
                    {
                        if (pass.Count > 0)
                        {
                            System.Console.Write("\b \b");
                            pass.Pop();
                        }
                    }
                    else if (chr == CTRLBACKSP)
                    {
                        while (pass.Count > 0)
                        {
                            System.Console.Write("\b \b");
                            pass.Pop();
                        }
                    }
                    else if (FILTERED.Count(x => chr == x) > 0) { }
                    else
                    {
                        pass.Push((char)chr);
                        System.Console.Write(mask);
                    }
                }

                System.Console.WriteLine();

                return new string(pass.Reverse().ToArray());
            }

            /// <summary>
            /// Like System.Console.ReadLine(), only with a mask.
            /// </summary>
            /// <returns>the string the user typed in </returns>
            public static string ReadPassword()
            {
                return Orb.App.Console.ReadPassword('*');
            }
        }
    }
}

