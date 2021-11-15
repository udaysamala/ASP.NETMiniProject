using OSCDTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSCDAL
{
    public class DAL
    {
        SqlConnection sqlConObj;
        SqlCommand sqlCmdObj;
        SqlDataReader sqlDataReaderObj;
        SqlDataReader sqlDataReaderObj1;
        SqlDataReader sqlDataReaderObj2;
        public DAL()
        {
            sqlConObj = new SqlConnection();
            sqlCmdObj = new SqlCommand();

        }
        
        public int Login(Customer c)
        {
            try
            {
                sqlConObj.ConnectionString = ConfigurationManager.
                    ConnectionStrings["OnlineShoppingCart"].ConnectionString;
                bool check = false;
                
                sqlConObj.Open();
                string query = "Select * from dbo.users";
                SqlCommand cmd = new SqlCommand(query, sqlConObj);
                SqlDataReader col = cmd.ExecuteReader();
                while (col.Read())
                {
                    if (c.Username == System.Convert.ToString(col[3]) && c.Password == System.Convert.ToString(col[4]))
                    {
                        check = true;
                        break;
                    }
                }
                sqlConObj.Close();
                if (check == true)
                    
                return 1;
                else
                    return -1;
            }
            catch(Exception e) { throw e; }
        }
        public int AdminLogin(Admin a)
        {
            if (a.User == "admin" && a.Pass == "admin")
            {
                return 1;
            }
            else
                return -1;
        }
        public int signup(Customer c)
        {
            try
            {
                sqlConObj.ConnectionString = ConfigurationManager.
                    ConnectionStrings["OnlineShoppingCart"].ConnectionString;
                
         
               

                string query = $"insert into dbo.users(name,mobile,username, Password,registeredAt) values('{c.Name}','{c.Mobile}','{c.Username}','{c.Password}',getdate())";
                SqlCommand cmd = new SqlCommand(query, sqlConObj);
                sqlConObj.Open();
                int insertedRows = cmd.ExecuteNonQuery();
                sqlConObj.Close();
                if (insertedRows >= 1)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
                
            }

            catch(Exception e) { throw e ; }
        }
        public int InsertintoProduct(Product p)
        {
            try
            {
                sqlConObj.ConnectionString = ConfigurationManager.
                    ConnectionStrings["OnlineShoppingCart"].ConnectionString;




                string query = $"insert into dbo.product(productid,title,summary,price,discount,quantity) values('{p.ProductId}','{p.Title}','{p.Summary}','{p.Price}','{p.Discount}','{p.Quantity}')";
                SqlCommand cmd = new SqlCommand(query, sqlConObj);
                sqlConObj.Open();
                int insertedRows = cmd.ExecuteNonQuery();
                sqlConObj.Close();
                if (insertedRows >= 1)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }

            }

            catch (Exception e) { throw e; }
        }
        public int InsertintoCart(ADDCart cr)
        {
            string qcheck="";
            try
            {
                sqlConObj.ConnectionString = ConfigurationManager.
                    ConnectionStrings["OnlineShoppingCart"].ConnectionString;


                string query = $"select productid,title,price,quantity from product where sno={cr.Check} or title ='{cr.Check}';";
                SqlCommand cmd = new SqlCommand(query, sqlConObj);
                sqlConObj.Open();
                
                sqlDataReaderObj1 = cmd.ExecuteReader();

                while (sqlDataReaderObj1.Read())
                {

                    {

                        cr.Productid = sqlDataReaderObj1[0].ToString();
                        cr.Productname = sqlDataReaderObj1[1].ToString();

                        cr.Price = sqlDataReaderObj1[2].ToString();
                        qcheck = sqlDataReaderObj1[3].ToString();

                    };
                    

                }
                sqlConObj.Close();
                if (Convert.ToInt32(cr.Quantity) <= Convert.ToInt32(qcheck))
                {
                    string query1 = $"insert into dbo.cart(username,productid,Productname,quantity,price) values('{cr.Username}','{cr.Productid}','{cr.Productname}','{cr.Quantity}','{cr.Price}')";
                    SqlCommand cmd1 = new SqlCommand(query1, sqlConObj);
                    sqlConObj.Open();
                    int insertedRows2 = cmd1.ExecuteNonQuery();
                    sqlConObj.Close();
                    if (insertedRows2 >= 1)
                    {
                        return 1;
                    }
                    else
                    {
                        return -1;
                    }

                }
                else
                {
                    return -1;
                }


                

                
                
                

            }

            catch (Exception e) { throw e; }
            
        }
        public int DeleteItemfrmProduct(Product p)
        {
            try
            {
                sqlConObj.ConnectionString = ConfigurationManager.
                    ConnectionStrings["OnlineShoppingCart"].ConnectionString;




                string query = $"DELETE FROM product WHERE productId={p.Deleteproduct};";
                SqlCommand cmd = new SqlCommand(query, sqlConObj);
                sqlConObj.Open();
                int insertedRows = cmd.ExecuteNonQuery();
                sqlConObj.Close();
                if (insertedRows >= 1)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }

            }

            catch (Exception e) { throw e; }
        }
        public List<Product> FetchAllProducts()
        {
            
            try
            {
                sqlConObj.ConnectionString = ConfigurationManager.
                   ConnectionStrings["OnlineShoppingCart"].ConnectionString;
                //SEtting up the command text for the command object
                sqlCmdObj.CommandText = @"SELECT SNO,title,price,quantity FROM dbo.product";
                sqlCmdObj.Connection = sqlConObj;

                //Execute
                sqlConObj.Open();//COnnection should be open not command
                //Connected Architecture
                //Reads on record at a time
                //Expects connection be open until all the records are read completely.
                sqlDataReaderObj = sqlCmdObj.ExecuteReader();
                List<Product> lstPro = new List<Product>();
                
                Product newepartObj = new Product();

                while (sqlDataReaderObj.Read())
                {
                    lstPro.Add(new Product()
                    {
                        Sno = sqlDataReaderObj[0].ToString(),
                        Title = sqlDataReaderObj[1].ToString(),
                        Price = sqlDataReaderObj[2].ToString(),
                        Quantity  = sqlDataReaderObj[3].ToString(),

                       
                    });

                }
                return lstPro;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                sqlConObj.Close();
            }

        }
        public List<ADDCart> FetchCart()
        {

            try
            {
                sqlConObj.ConnectionString = ConfigurationManager.
                   ConnectionStrings["OnlineShoppingCart"].ConnectionString;
                //SEtting up the command text for the command object
                Customer c = new Customer();
                string query = $"SELECT[SNO.],productname,quantity,price FROM dbo.cart WHERE username = '{c.Username}'";
                SqlCommand cmd = new SqlCommand(query, sqlConObj);
                
                //sqlCmdObj.CommandText = @"SELECT [SNO.],productname,quantity,price FROM dbo.cart WHERE username='{}'";
                //sqlCmdObj.Connection = sqlConObj;

                //Execute
                sqlConObj.Open();//COnnection should be open not command
                //Connected Architecture
                //Reads on record at a time
                //Expects connection be open until all the records are read completely.
                sqlDataReaderObj2 = cmd.ExecuteReader();
                List<ADDCart> lstCart = new List<ADDCart>();

                ADDCart newepartObj = new ADDCart();

                while (sqlDataReaderObj2.Read())
                {
                    lstCart.Add(new ADDCart()
                    {
                        Sno = sqlDataReaderObj2[0].ToString(),
                        Productname = sqlDataReaderObj2[1].ToString(),
                        Price = sqlDataReaderObj2[2].ToString(),
                        Quantity = sqlDataReaderObj2[3].ToString(),


                    });

                }
                return lstCart;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                sqlConObj.Close();
            }

        }
        public List<Product> AdminFetchProducts()
        {

            try
            {
                sqlConObj.ConnectionString = ConfigurationManager.
                   ConnectionStrings["OnlineShoppingCart"].ConnectionString;
                //SEtting up the command text for the command object
                sqlCmdObj.CommandText = @"SELECT SNO,productid,title,price,quantity FROM dbo.product";
                sqlCmdObj.Connection = sqlConObj;

                //Execute
                sqlConObj.Open();//COnnection should be open not command
                //Connected Architecture
                //Reads on record at a time
                //Expects connection be open until all the records are read completely.
                sqlDataReaderObj = sqlCmdObj.ExecuteReader();
                List<Product> lstPro1 = new List<Product>();

                Product newepartObj = new Product();

                while (sqlDataReaderObj.Read())
                {
                    lstPro1.Add(new Product()
                    {
                        Sno = sqlDataReaderObj[0].ToString(),
                        ProductId= sqlDataReaderObj[1].ToString(),
                        Title = sqlDataReaderObj[2].ToString(),
                        Price = sqlDataReaderObj[3].ToString(),
                        Quantity = sqlDataReaderObj[4].ToString(),


                    });

                }
                return lstPro1;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                sqlConObj.Close();
            }

        }


    }
}
