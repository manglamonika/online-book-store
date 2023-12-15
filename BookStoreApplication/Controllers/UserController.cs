using BookBusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStoreApplication.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetUserList()

        {
            UserService us = new UserService();
            List<tbl_Users> userList = us.GetAllUserDetails();
            return Json(userList, JsonRequestBehavior.AllowGet);

        }
        public JsonResult AddUser(tbl_Users book)
        {
            if (book != null)
            {
                UserService us = new UserService();
                bool bookflag = us.AddUser(book);
                return Json(bookflag, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Some Error Occured");
            }
        }
        [HttpPost]
        public string UpdateUser(tbl_Users user)
        {
            if (user != null)
            {
                UserService us = new UserService();
                string result = us.UpdateUser(user);
                return result;
            }
            else
            {
                return "Oops! something went wrong.";
            }
        }
        [HttpPost]
        public string DeleteUser(int? UserId)
        {
            if (UserId != null)
            {
                UserService us = new UserService();
                string result = us.DeleteUser(UserId);
                return result;
            }
            else
            {
                return " Oops! Error occered.";
            }
        }

    }
}