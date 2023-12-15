using BookBusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStoreApplication.Controllers
{
    public class ViewBookController : Controller
    {
        // GET: ViewBook
        public ActionResult Index()
        {
            if (Session["Name"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
           // return View();
        }
        
        public JsonResult GetViewBookList()

        {
            BookService bs = new BookService();
            int userId = Convert.ToInt32(Session["UserId"]);
            List<tbl_Book> bookList = bs.GetBookDetailsById(userId);
            return Json(bookList, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult ViewBook(tbl_Book book)
        {
            if (book != null)
            {
                BookService bs = new BookService();
                int userId = Convert.ToInt32(Session["UserId"]);
                List<tbl_Book> bookList = bs.ViewBook(book, userId);
                return Json(bookList, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Some Error Occured");
            }
        }

        [HttpPost]
        public JsonResult SellBook(tbl_Book book)
        {
            if (book != null)
            {
                BookService bs = new BookService();
                int userId = Convert.ToInt32(Session["UserId"]);
                bool bookflag = bs.SellBook(book, userId);
                return Json(bookflag, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Some Error Occured");
            }
        }
    }
}