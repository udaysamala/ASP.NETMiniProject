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
using System.Net.Http;

namespace OnlineShoppingCart_WEBAPI.Controllers.Tests
{
    [TestClass()]
    public class OnlineShoppingCartControllerTests
    {
        [TestMethod()]
        public void CheckLoginTest()
        {
            int expectedResult = 1;

            Customer testCustObj = new Customer()
            {
             Username = "uday",
             Password = "uday"
             };


        //Setting Up Mock : Moq Framework
        //Creates a fake object / mock object of the BL Interface (Cause interface holds the methods that are part of our actual BL)         
        Mock<IBL> mockBLObj = new Mock<IBL>();
        mockBLObj.Setup(x=>x.CheckLogin(testCustObj)).Returns(() => expectedResult);


            OnlineShoppingCartController TCObj = new OnlineShoppingCartController (mockBLObj.Object);
            TCObj.Request = new System.Net.Http.HttpRequestMessage()
            {
                Properties =
                {
                    {
                        HttpPropertyKeys.HttpConfigurationKey,new HttpConfiguration()
                    }
                }
            };

            var actualResult = TCObj.CheckLogin(testCustObj);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(HttpStatusCode.OK, actualResult.StatusCode);
           
        }
    
        [TestMethod()]
        public void signupTest()
        {
            int expectedResult = 1;

            Customer testCustObj = new Customer()
            {
                Username = "uday",
                Password = "uday",
                Name="udaykumar",
                Mobile="9059394139"
            };


            //Setting Up Mock : Moq Framework
            //Creates a fake object / mock object of the BL Interface (Cause interface holds the methods that are part of our actual BL)         
            Mock<IBL> mockBLObj = new Mock<IBL>();
            mockBLObj.Setup(x => x.regsignup(testCustObj)).Returns(() => expectedResult);


            OnlineShoppingCartController TCObj = new OnlineShoppingCartController(mockBLObj.Object);
            TCObj.Request = new System.Net.Http.HttpRequestMessage()
            {
                Properties =
                {
                    {
                        HttpPropertyKeys.HttpConfigurationKey,new HttpConfiguration()
                    }
                }
            };

            var actualResult = TCObj.signup(testCustObj);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(HttpStatusCode.OK, actualResult.StatusCode);
        }

        [TestMethod()]
        public void admincheckTest()
        {
            int expectedResult = 1;

            Admin testObj = new Admin()
            {
                User = "admin",
                Pass= "admin"
            };


            //Setting Up Mock : Moq Framework
            //Creates a fake object / mock object of the BL Interface (Cause interface holds the methods that are part of our actual BL)         
            Mock<IBL> mockBLObj = new Mock<IBL>();
            mockBLObj.Setup(x => x.checkadminlogin(testObj)).Returns(() => expectedResult);


            OnlineShoppingCartController TCObj = new OnlineShoppingCartController(mockBLObj.Object);
            TCObj.Request = new System.Net.Http.HttpRequestMessage()
            {
                Properties =
                {
                    {
                        HttpPropertyKeys.HttpConfigurationKey,new HttpConfiguration()
                    }
                }
            };

            var actualResult = TCObj.admincheck(testObj);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(HttpStatusCode.OK, actualResult.StatusCode);
        }

        [TestMethod()]
        public void InsertintoProductTableTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AdminViewProductsTest()
        {
            
            List<Product> expectedResult = new List<Product>();
            Product testProObj = new Product()
            {
                Sno = "1",
                ProductId = "123",
                Title = "Pen",
                Price = "15",
                Quantity = "40",
            };
            expectedResult.Add(testProObj);

            //Setting Up Mock : Moq Framework
            //Creates a fake object / mock object of the BL Interface (Cause interface holds the methods that are part of our actual BL)
            Mock<IBL> mockBLObj = new Mock<IBL>();
            //Using mockObject : Setting up the GetAllDepartment to return our expected result
            mockBLObj.Setup(x => x.AdminProductDetails()).Returns(() => expectedResult);

            OnlineShoppingCartController testControllerObj = new OnlineShoppingCartController(mockBLObj.Object);
            testControllerObj.Request = new System.Net.Http.HttpRequestMessage()
            {
                Properties =
                {
                    {
                        HttpPropertyKeys.HttpConfigurationKey,new HttpConfiguration()
                    }
                }
            };

            var actualResult = testControllerObj.AdminViewProducts();

            //Assert

            Assert.AreEqual(HttpStatusCode.OK, actualResult.StatusCode);
            var actualContent = actualResult.Content.ReadAsAsync<List<Product>>().Result;
           
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
            List<ADDCart> expectedResult = new List<ADDCart>();
            ADDCart testObj = new ADDCart()
            {
                Sno = "1",
                
                
                Price = "15",
                Quantity = "40",
            };
            expectedResult.Add(testObj);

            //Setting Up Mock : Moq Framework
            //Creates a fake object / mock object of the BL Interface (Cause interface holds the methods that are part of our actual BL)
            Mock<IBL> mockBLObj = new Mock<IBL>();
            //Using mockObject : Setting up the GetAllDepartment to return our expected result
            mockBLObj.Setup(x => x.FetchCart()).Returns(() => expectedResult);

            OnlineShoppingCartController testControllerObj = new OnlineShoppingCartController(mockBLObj.Object);
            testControllerObj.Request = new System.Net.Http.HttpRequestMessage()
            {
                Properties =
                {
                    {
                        HttpPropertyKeys.HttpConfigurationKey,new HttpConfiguration()
                    }
                }
            };

            var actualResult = testControllerObj.ViewCart();

            //Assert

            Assert.AreEqual(HttpStatusCode.OK, actualResult.StatusCode);
            var actualContent = actualResult.Content.ReadAsAsync<List<ADDCart>>().Result;
        }
    }
}