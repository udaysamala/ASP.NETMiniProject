using OSCDAL;
using OSCDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSCBL
{
    public class BL:IBL
    {
        DAL dalObj = new DAL();
        public int CheckLogin(Customer newObj)
        {
            try
            {
                
                int result = dalObj.Login(newObj);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int checkadminlogin(Admin newadmin)
        {
            try
            {
                int result = dalObj.AdminLogin(newadmin);
                return result;


            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public int regsignup(Customer newObj1)
        {
            try
            {

                int result = dalObj.signup(newObj1);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int InsertintoProductTable(Product newObj1)
        {
            try
            {

                int result = dalObj.InsertintoProduct(newObj1);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int InsertintoCart(ADDCart newObj4)
        {
            try
            {

                int result = dalObj.InsertintoCart(newObj4);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int DeleteProductItem(Product newObj2)
        {
            try
            {

                int result = dalObj.DeleteItemfrmProduct(newObj2);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<Product> GetAllProductDetails()
        {
            try
            {
                
                List<Product> results = dalObj.FetchAllProducts();
                return results;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<Product> AdminProductDetails()
        {
            try
            {

                List<Product> results = dalObj.AdminFetchProducts();
                return results;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<ADDCart> FetchCart()
        {
            try
            {

                List<ADDCart> results = dalObj.FetchCart();
                return results;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
