using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using WebAPI.Controllers;
//using WebAPI.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using MVC.Controllers;
using WebAPI.Models;
using System.Web.Mvc;
using MVC.Models;

namespace UnitTestContactInfo
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetContactsWithModelObject()
        {
            //Arrange
            var testGetContacts = GetAllContacts();
            UserInfoController mvcContr = new UserInfoController();
            mvcUserInfoModel model = new mvcUserInfoModel();
            //Act
            var result = mvcContr.AddOrEdit(model);
            //Assert
            Assert.IsNotNull(result); 
            Assert.IsInstanceOfType(result, typeof(System.Web.Mvc.RedirectToRouteResult)); 
        }

        [TestMethod]
        public void TestUpdateContactById()
        {
            //Arrange
            var testGetContacts = GetAllContacts();
            UserInfoController mvcContr = new UserInfoController();
            //Act
            ActionResult result = mvcContr.AddOrEdit(1); 
            //Assert
            Assert.IsNotNull(result); 
            Assert.IsInstanceOfType(result, typeof(System.Web.Mvc.ViewResult)); 
        }

        [TestMethod]
        public void TestContactContact()
        {
            //Arrange
            var testGetContacts = GetAllContacts();
            UserInfoController mvcContr = new UserInfoController();
            //Act
            ActionResult result = mvcContr.Delete(1);
            //Assert
            Assert.IsNotNull(result); 
            Assert.IsInstanceOfType(result, typeof(System.Web.Mvc.RedirectToRouteResult));
        }
       
        private List<UserInfo> GetAllContacts() {
            var testContacts = new List<UserInfo>();
            testContacts.Add(new UserInfo { ID=1, Email="17snehal@gmail.com", FirstName="Snehal", LastName="Kolhe", PhoneNumber="+91 9970022882", Status="Married"});
            return testContacts;
        }
    }
}
