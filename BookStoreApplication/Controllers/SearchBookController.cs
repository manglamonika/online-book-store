using BookBusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStoreApplication.Controllers
{
    public class SearchBookController : Controller
    {
        // GET: SearchBook
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
            
        }

        public JsonResult GetViewBookList()

        {
            BookService bs = new BookService();
            int userId = Convert.ToInt32(Session["UserId"]);
            List<tblOrderBook> bookList = bs.GetBookDetailsByOtherId(userId);
            return Json(bookList, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult ViewBook(tblOrderBook orderbook)
        {
            if (orderbook != null)
            {
                BookService bs = new BookService();
                int userId = Convert.ToInt32(Session["UserId"]);
                List<tblOrderBook> bookList = bs.ViewOtherBook(orderbook, userId);
                return Json(bookList, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Some Error Occured");
            }
        }

        [HttpPost]
        public JsonResult BuyBook(tblOrderBook book)
        {
            if (book != null)
            {
                BookService bs = new BookService();
                int userId = Convert.ToInt32(Session["UserId"]);
                bool bookflag = bs.BuyBook(book, userId);
                return Json(bookflag, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Some Error Occured");
            }
        }
    }
}