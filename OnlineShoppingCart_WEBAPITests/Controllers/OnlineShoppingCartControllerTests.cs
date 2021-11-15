using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineShoppingCart_WEBAPI.Controllers;
using OSCBL;
using OSCDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Web.Http.Hosting;
using System.Web.Http;

namespace OnlineShoppingCart_WEBAPI.Controllers.Tests
{
    [TestClass()]
    public class OnlineShoppingCartControllerTests
    {
        [TestMethod()]
        public void CheckLoginTest(Customer c)
        {
            

             c.Username = "userTest";
            c.Password = "passwordTest";


//Setting Up Mock : Moq Framework
//Creates a fake object / mock object of the BL Interface (Cause interface holds the methods that are part of our actual BL)         
        Mock<IBL> mockBLObj = new Mock<IBL>();
        mockBLObj.Setup(x=>x.CheckLogin(c)).Returns(() => expectedResult);


            OnlineShoppingCartController TCObj = new OnlineShoppingCartController (mockBLObj.Object);
            TCObj.Request = new System.Net.Http.HttpRequestMessage()
            {
                Properties=
                {
                    {
                        HttpPropertyKeys.HttpConfigurationKey,new HttpConfiguration()
                    }
                }
            };

var actualResult = TCObj.CheckLogin(Customer neobj);

//Assert

Assert.AreEqual(HttpStatusCode.OK, actualResult.StatusCode);
var actualContent = actualResult.Content.ReadAsAsync<List<Customer>>().Result;
Assert.AreEqual(expectedResult[0].username, actualContent[0].username);


           
        }
    

            
        

        [TestMethod()]
        public void signupTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void admincheckTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void InsertintoProductTableTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AdminViewProductsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AdminDeleteProductTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void InsertintoCartTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ViewCartTest()
        {
            Assert.Fail();
        }
    }
}