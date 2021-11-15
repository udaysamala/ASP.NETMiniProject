using OSCBL;
using OSCDAL;
using OSCDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OnlineShoppingCart_WEBAPI.Controllers
{
    
   
        
        public class OnlineShoppingCartController : ApiController
    {
            private readonly IBL blObj;
            //Mocking of your BL : Testing of Controller
            public OnlineShoppingCartController(IBL iObj)
            {
                blObj = iObj;
            }


            public OnlineShoppingCartController() : this(new BL())
            {

            }
            DAL dal = new DAL();

        BL bl = new BL();
        [HttpPost]
        public HttpResponseMessage CheckLogin(Customer dto)//Username,Password
        {
            try
            {
                int result1 = bl.CheckLogin(dto);
                if (result1 == 1)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Welcome " + dto.Username);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Invalid/No data found! please signup");
                    
                }

            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            

        }
        [HttpPost]
        public HttpResponseMessage signup(Customer dto)////Username,Password,Name,Mobile
        {
            try
            {
                int result1 = bl.regsignup(dto);
                if (result1 == 1)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Registration Successfull! You can Login Now");
                    
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Registartion Unsuccessfull");

                }

            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            
        }
        [HttpPost]
        public HttpResponseMessage admincheck(Admin dto)//user.pass
        {
            try
            {
                int result = bl.checkadminlogin(dto);
                if (result == 1)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Welcome " + dto.User);

                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Invalid Login credentials!");
                }

                
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }
    
        [HttpPost]
        public HttpResponseMessage InsertintoProductTable(Product dto)//productId,title,summary,price,discount,quantity
        {
            try
            {
                int result2 = bl.InsertintoProductTable(dto);
                if (result2 == 1)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Product Inserted Successfull! You Can View Product");
                    
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Product NotInserted! Unsuccessfull");
                    

                }

            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            
        }
        public HttpResponseMessage AdminViewProducts()
        {
            try
            {
                var result = bl.AdminProductDetails();
                if (result != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NoContent, "No Data Exists");
                }


            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            
        }
        [HttpPost]
        public HttpResponseMessage AdminDeleteProduct(Product dto)//deleteproduct
        {
            try
            {

                int result3 = bl.DeleteProductItem(dto);
                if (result3 == 1)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Product Deleted Successfull! You Can View Product");

                    
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Product NotDeleted! Unsuccessfull");


                }

            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            
        }
        [HttpPost]
        public HttpResponseMessage InsertintoCart(ADDCart crdto)//Username,Check,Quantity
        {
            try
            {
                int result2 = bl.InsertintoCart(crdto);
                if (result2 == 1)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Product Inserted Successfull! You Can View Cart");
                    
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NoContent, "Product NotInserted! Check Quantity");
               

                }

            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            
        }
        [HttpGet]
        public HttpResponseMessage ViewCart()
        {
            try
            {
                var result  = bl.FetchCart();
                if (result != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NoContent, "No Data Exists");
                }
                

            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            
        }


    }
}
