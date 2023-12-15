using BookBusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStoreApplication.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            if (Session["Name"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index","Login");
            }


        }
        [HttpPost]
        public JsonResult AddBook(tbl_Book book)
        {
            if (book != null)
            {
                BookService bs = new BookService();
                int userId = Convert.ToInt32(Session["UserId"]);
                bool bookflag = bs.AddBook(book, userId);
                return Json(bookflag, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Some Error Occured");
            }
        }

        [HttpPost]
        public JsonResult EditBook(tbl_Book book)
        {
            if (book != null)
            {
                BookService bs = new BookService();
                List<tbl_Book> bookList = bs.EditBook(book);
                return Json(bookList, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Some Error Occured");
            }
        }
        
        public JsonResult GetBookList()

        {
            BookService bs = new BookService();
            int userId = Convert.ToInt32(Session["UserId"]);
            List<tbl_Book> bookList = bs.GetAllBookDetails(userId);

                return Json(bookList, JsonRequestBehavior.AllowGet);
           
        }
        [HttpPost]
        public string UpdateBook(tbl_Book book)
        {
            if (book != null)
            {
                BookService bs = new BookService();
                string result = bs.UpdateBook(book);
                return result;
            }
            else
            {
                return "Oops! something went wrong.";
            }
        }
        [HttpPost]
        public string DeleteBook(int? BookId)
        {
            if (BookId != null)
            {
                BookService bs = new BookService();
                int BookId1 = Convert.ToInt32(BookId);
                int userId = Convert.ToInt32(Session["UserId"]);
                string result = bs.DeleteBook(BookId1, userId);
                return result;
            }
            else
            {
                return " Oops! Error occered.";
            }
        }


    }
}