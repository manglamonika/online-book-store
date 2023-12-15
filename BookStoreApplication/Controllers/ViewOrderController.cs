using BookBusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStoreApplication.Controllers
{
    public class ViewOrderController : Controller
    {
        // GET: ViewOrder
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
        public JsonResult GetViewAllOrderBooks()

        {
            BookService bs = new BookService();
            int userId = Convert.ToInt32(Session["UserId"]);
            List<tblOrderBook> bookList = bs.GetOrderDetailsById(userId);
            return Json(bookList, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult ViewOrder(tblOrderBook orderbook)
        {
            if (orderbook != null)
            {
                BookService bs = new BookService();
                int userId = Convert.ToInt32(Session["UserId"]);
                List<tblOrderBook> bookList = bs.ViewOrderBookDetails(orderbook, userId);
                return Json(bookList, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Some Error Occured");
            }
        }
    }
}