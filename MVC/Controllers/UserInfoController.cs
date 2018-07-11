using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class UserInfoController : Controller
    {
        // GET: userInfoMVC
        public ActionResult Index()
        {
            IEnumerable<mvcUserInfoModel> userInfo;
            HttpResponseMessage response = GlobalVariables.webApiClient.GetAsync("UserInfo").Result;
            userInfo = response.Content.ReadAsAsync<IEnumerable<mvcUserInfoModel>>().Result;
            return View(userInfo);
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new mvcUserInfoModel());
            else
            {
                HttpResponseMessage resp = GlobalVariables.webApiClient.GetAsync("UserInfo/"+ id.ToString()).Result;
                return View(resp.Content.ReadAsAsync<mvcUserInfoModel>().Result);
                 
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(mvcUserInfoModel userInfo)
        {
            if (userInfo.ID == 0)
            {
                HttpResponseMessage resp = GlobalVariables.webApiClient.PostAsJsonAsync("UserInfo", userInfo).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage resp = GlobalVariables.webApiClient.PutAsJsonAsync("UserInfo/" + userInfo.ID, userInfo).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            
            return RedirectToAction("Index");
        }
        
        public ActionResult Delete(int id)
        {
            HttpResponseMessage resp = GlobalVariables.webApiClient.DeleteAsync("UserInfo/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }

    }
}