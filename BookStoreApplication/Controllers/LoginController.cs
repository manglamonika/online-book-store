using BookBusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStoreApplication.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(tblloginUser user)
        {
            if (user != null)
            {
                LoginService ls = new LoginService();
                DataTable dt  = ls.Login(user);
                if(dt.Rows.Count>0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        Session["UserId"] = (int)dt.Rows[i]["UserId"];
                        Session["Name"] = dt.Rows[i]["Name"].ToString();
                        bool flag = (bool)dt.Rows[i]["IsAdmin"];
                        if(flag==true)
                        {
                            Session["IsAdmin"] = "ADMIN";
                        }

                    }
                    //return RedirectToAction("Index", "Home");
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                else
                        {
                    return Json(false, JsonRequestBehavior.AllowGet);
                    //return RedirectToAction("Index", "Login");

                }
                
                
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}