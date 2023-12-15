using BookBusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStoreApplication.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddUsers(tbl_Users user)
        {
            if (user != null)
            {
                RegistrationService rs = new RegistrationService();
                bool bookflag = rs.AddUsers(user);
                return Json(bookflag, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Some Error Occured");
            }
        }
    }
}