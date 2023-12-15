using BookDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBusinessLayer
{
   public class BookService
    {

        public BookService()
        {

        }

        public bool AddBook(tbl_Book book,int userId)
        {
            BookDetailDAL bl = new BookDetailDAL();
            string query = "insert into tblBooks(Name,IsBn,Price,Auther,Publisher,Publisheddate,Description,Language,OrderStatusId,UserId) values('" + book.Name+ "','" + book.IsBn + "','" + book.Price + "','" + book.Auther + "','" + book.Publisher + "','" + book.Publisheddate + "','" + book.Description + "','" + book.Language + "',1,'" + userId + "')";
            bool flag = bl.DMLOpperation(query);

            
            return flag;
        }

        public List<tbl_Book> EditBook(tbl_Book book)
        {
            BookDetailDAL bl = new BookDetailDAL();
            string query = "select BookId,Name,Price,IsBn,Auther,Publisher,Publisheddate,Description,Language,OrderStatusId from tblBooks where BookId='" + book.BookId + "'";
            DataTable dt = bl.SelactAll(query);

            List<tbl_Book> bookList = new List<tbl_Book>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tbl_Book book1 = new tbl_Book();
                book1.BookId = (int)dt.Rows[i]["BookId"];
                book1.Name = dt.Rows[i]["Name"].ToString();
               // book1.Email = dt.Rows[i]["Email"].ToString();
                book1.Price = Convert.ToDecimal(dt.Rows[i]["Price"]);
                book1.IsBn = Convert.ToString(dt.Rows[i]["IsBn"]);
                book1.Auther = Convert.ToString(dt.Rows[i]["Auther"]);
                book1.Publisher = Convert.ToString(dt.Rows[i]["Publisher"]);
                book1.Publisheddate = DateTime.Parse((dt.Rows[i]["Publisheddate"].ToString())).ToString("dd/MM/yyyy"); //dt.Rows[i]["Publisheddate"].ToString().ToString("MM/dd/yyyy");
                book1.Description = Convert.ToString(dt.Rows[i]["Description"]);
                book1.Language = Convert.ToString(dt.Rows[i]["Language"]);
                book1.StatusInfo = Convert.ToInt32(dt.Rows[i]["OrderStatusId"]);
                // book.Address = dt.Rows[i]["Address"].ToString();

                bookList.Add(book1);
            }
            return bookList;
        }

        
      public List<tblOrderBook> GetBookDetailsByOtherId(int userId)
        {
            BookDetailDAL bl = new BookDetailDAL();
            string query = " select ot.OrderId as OrderId,tb.BookId as BookId,Name,Price,IsBn,Auther,Publisher,Publisheddate,Description,Language,ot.OrderStatusId as OrderStatusId from tblBooks tb join tblOrders ot on tb.BookId=ot.BookId where tb.UserId!='" + userId + "'";
            DataTable dt = bl.SelactAll(query);

            List<tblOrderBook> bookList = new List<tblOrderBook>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tblOrderBook book1 = new tblOrderBook();
                book1.OrderId = (int)dt.Rows[i]["OrderId"];
                book1.BookId = (int)dt.Rows[i]["BookId"];
                book1.Name = dt.Rows[i]["Name"].ToString();
                //book1.Email = dt.Rows[i]["Email"].ToString();
                book1.Price = Convert.ToDecimal(dt.Rows[i]["Price"]);
                book1.IsBn = Convert.ToString(dt.Rows[i]["IsBn"]);
                book1.Auther = Convert.ToString(dt.Rows[i]["Auther"]);
                book1.Publisher = Convert.ToString(dt.Rows[i]["Publisher"]);
                book1.Publisheddate = DateTime.Parse((dt.Rows[i]["Publisheddate"].ToString())).ToString("dd/MM/yyyy"); //dt.Rows[i]["Publisheddate"].ToString().ToString("MM/dd/yyyy");
                book1.Description = Convert.ToString(dt.Rows[i]["Description"]);
                book1.Language = Convert.ToString(dt.Rows[i]["Language"]);
                book1.StatusInfo = Convert.ToInt32(dt.Rows[i]["OrderStatusId"]);
                // book.Address = dt.Rows[i]["Address"].ToString();

                bookList.Add(book1);
            }
            return bookList;
        }
        public List<tblOrderBook> GetOrderDetailsById(int userId)
        {
            BookDetailDAL bl = new BookDetailDAL();
            string query = " select ot.OrderId as OrderId,tb.BookId as BookId,Name,Price,IsBn,Auther,Publisher,Publisheddate,Description,Language,ot.OrderStatusId as OrderStatusId from tblBooks tb join tblOrders ot on tb.BookId=ot.BookId where tb.UserId='" + userId + "'or BuyUserId='" + userId + "'";
            DataTable dt = bl.SelactAll(query);

            List<tblOrderBook> bookList = new List<tblOrderBook>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tblOrderBook book1 = new tblOrderBook();
                book1.OrderId = (int)dt.Rows[i]["OrderId"];
                book1.BookId = (int)dt.Rows[i]["BookId"];
                
                book1.Name = dt.Rows[i]["Name"].ToString();
                //book1.Email = dt.Rows[i]["Email"].ToString();
                book1.Price = Convert.ToDecimal(dt.Rows[i]["Price"]);
                book1.IsBn = Convert.ToString(dt.Rows[i]["IsBn"]);
                book1.Auther = Convert.ToString(dt.Rows[i]["Auther"]);
                book1.Publisher = Convert.ToString(dt.Rows[i]["Publisher"]);
                book1.Publisheddate = DateTime.Parse((dt.Rows[i]["Publisheddate"].ToString())).ToString("dd/MM/yyyy"); //dt.Rows[i]["Publisheddate"].ToString().ToString("MM/dd/yyyy");
                book1.Description = Convert.ToString(dt.Rows[i]["Description"]);
                book1.Language = Convert.ToString(dt.Rows[i]["Language"]);
                book1.StatusInfo = Convert.ToInt32(dt.Rows[i]["OrderStatusId"]);
                // book.Address = dt.Rows[i]["Address"].ToString();

                bookList.Add(book1);
            }
            return bookList;
        }
        
        public List<tbl_Book> GetBookDetailsById(int  userId)
        {
            BookDetailDAL bl = new BookDetailDAL();
            string query = "select BookId,Name,Price,IsBn,Auther,Publisher,Publisheddate,Description,Language,OrderStatusId from tblBooks where UserId='" + userId + "'";
            DataTable dt = bl.SelactAll(query);

            List<tbl_Book> bookList = new List<tbl_Book>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tbl_Book book1 = new tbl_Book();
                book1.BookId = (int)dt.Rows[i]["BookId"];
                book1.Name = dt.Rows[i]["Name"].ToString();
               // book1.Email = dt.Rows[i]["Email"].ToString();
                book1.Price = Convert.ToDecimal(dt.Rows[i]["Price"]);
                book1.IsBn = Convert.ToString(dt.Rows[i]["IsBn"]);
                book1.Auther = Convert.ToString(dt.Rows[i]["Auther"]);
                book1.Publisher = Convert.ToString(dt.Rows[i]["Publisher"]);
                book1.Publisheddate = DateTime.Parse((dt.Rows[i]["Publisheddate"].ToString())).ToString("dd/MM/yyyy"); //dt.Rows[i]["Publisheddate"].ToString().ToString("MM/dd/yyyy");
                book1.Description = Convert.ToString(dt.Rows[i]["Description"]);
                book1.Language = Convert.ToString(dt.Rows[i]["Language"]);
                book1.StatusInfo = Convert.ToInt32(dt.Rows[i]["OrderStatusId"]);
                // book.Address = dt.Rows[i]["Address"].ToString();

                bookList.Add(book1);
            }
            return bookList;
        }

        public bool SellBook(tbl_Book book, int userId)
        {
            BookDetailDAL bl = new BookDetailDAL();
            //string query = "insert into tblOrders(BookId,UserId,OrderStatusId) values('" + book.BookId + "','" + userId + "',2)";
            //bool flag = bl.DMLOpperation(query);
            //string query2 = "update tblBooks set OrderStatusId=3 where  BookId='" + book.BookId + "' and UserId='" + userId + "'";
            //bool flag2 = bl.DMLOpperation(query);
            string query = "SP_SellBooks";
            bool flag = bl.ProcedureOperation(query, book.BookId, userId);
            return flag;
        }

        public bool BuyBook(tblOrderBook orderbook, int userId)
        {
            BookDetailDAL bl = new BookDetailDAL();
            string query = "update tblOrders set OrderStatusId=3,BuyUserId='" + userId + "' where OrderId='" + orderbook.OrderId + "' and  BookId='" + orderbook.BookId + "'";
            bool flag = bl.DMLOpperation(query);
           

            return flag;
        }
        public List<tbl_Book> ViewBook(tbl_Book book, int userId)
        {
            BookDetailDAL bl = new BookDetailDAL();
            string query = "select BookId,Name,Price,IsBn,Auther,Publisher,Publisheddate,Description,Language,OrderStatusId from tblBooks where UserId='" + userId + "' and Name like '%" + book.Name+ "%'";
            DataTable dt = bl.SelactAll(query);

            List<tbl_Book> bookList = new List<tbl_Book>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tbl_Book book1 = new tbl_Book();
                book1.BookId = (int)dt.Rows[i]["BookId"];
                book1.Name = dt.Rows[i]["Name"].ToString();
                //book1.Email = dt.Rows[i]["Email"].ToString();
                book1.Price = Convert.ToDecimal(dt.Rows[i]["Price"]);
                book1.IsBn = Convert.ToString(dt.Rows[i]["IsBn"]);
                book1.Auther = Convert.ToString(dt.Rows[i]["Auther"]);
                book1.Publisher = Convert.ToString(dt.Rows[i]["Publisher"]);
                book1.Publisheddate = DateTime.Parse((dt.Rows[i]["Publisheddate"].ToString())).ToString("dd/MM/yyyy"); //dt.Rows[i]["Publisheddate"].ToString().ToString("MM/dd/yyyy");
                book1.Description = Convert.ToString(dt.Rows[i]["Description"]);
                book1.Language = Convert.ToString(dt.Rows[i]["Language"]);
                book1.StatusInfo = Convert.ToInt32(dt.Rows[i]["OrderStatusId"]);
                // book.Address = dt.Rows[i]["Address"].ToString();

                bookList.Add(book1);
            }
            return bookList;
        }
        public List<tblOrderBook> ViewOtherBook(tblOrderBook book, int userId)
        {
            BookDetailDAL bl = new BookDetailDAL();
            string query = "select ot.OrderId as OrderId,tb.BookId as BookId,Name,Price,IsBn,Auther,Publisher,Publisheddate,Description,Language,ot.OrderStatusId as OrderStatusId from tblBooks tb join tblOrders ot on tb.BookId=ot.BookId where tb.UserId!='" + userId + "' and Name like '%" + book.Name + "%'";
            DataTable dt = bl.SelactAll(query);

            List<tblOrderBook> bookotherList = new List<tblOrderBook>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tblOrderBook book1 = new tblOrderBook();
                book1.OrderId = (int)dt.Rows[i]["OrderId"];
                book1.BookId = (int)dt.Rows[i]["BookId"];
                book1.Name = dt.Rows[i]["Name"].ToString();
                //book1.Email = dt.Rows[i]["Email"].ToString();
                book1.Price = Convert.ToDecimal(dt.Rows[i]["Price"]);
                book1.IsBn = Convert.ToString(dt.Rows[i]["IsBn"]);
                book1.Auther = Convert.ToString(dt.Rows[i]["Auther"]);
                book1.Publisher = Convert.ToString(dt.Rows[i]["Publisher"]);
                book1.Publisheddate = DateTime.Parse((dt.Rows[i]["Publisheddate"].ToString())).ToString("dd/MM/yyyy"); //dt.Rows[i]["Publisheddate"].ToString().ToString("MM/dd/yyyy");
                book1.Description = Convert.ToString(dt.Rows[i]["Description"]);
                book1.Language = Convert.ToString(dt.Rows[i]["Language"]);
                book1.StatusInfo = Convert.ToInt32(dt.Rows[i]["OrderStatusId"]);
                // book.Address = dt.Rows[i]["Address"].ToString();

                bookotherList.Add(book1);
            }
            return bookotherList;
        }
        public List<tblOrderBook> ViewOrderBookDetails(tblOrderBook book, int userId)
        {
            BookDetailDAL bl = new BookDetailDAL();
            string query = "select ot.OrderId as OrderId,tb.BookId as BookId,Name,Price,IsBn,Auther,Publisher,Publisheddate,Description,Language,ot.OrderStatusId as OrderStatusId from tblBooks tb join tblOrders ot on tb.BookId=ot.BookId where tb.UserId='" + userId + "' and Name like '%" + book.Name + "%'";
            DataTable dt = bl.SelactAll(query);

            List<tblOrderBook> bookotherList = new List<tblOrderBook>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tblOrderBook book1 = new tblOrderBook();
                book1.OrderId = (int)dt.Rows[i]["OrderId"];
                book1.BookId = (int)dt.Rows[i]["BookId"];
                book1.Name = dt.Rows[i]["Name"].ToString();
                //book1.Email = dt.Rows[i]["Email"].ToString();
                book1.Price = Convert.ToDecimal(dt.Rows[i]["Price"]);
                book1.IsBn = Convert.ToString(dt.Rows[i]["IsBn"]);
                book1.Auther = Convert.ToString(dt.Rows[i]["Auther"]);
                book1.Publisher = Convert.ToString(dt.Rows[i]["Publisher"]);
                book1.Publisheddate = DateTime.Parse((dt.Rows[i]["Publisheddate"].ToString())).ToString("dd/MM/yyyy"); //dt.Rows[i]["Publisheddate"].ToString().ToString("MM/dd/yyyy");
                book1.Description = Convert.ToString(dt.Rows[i]["Description"]);
                book1.Language = Convert.ToString(dt.Rows[i]["Language"]);
                book1.StatusInfo = Convert.ToInt32(dt.Rows[i]["OrderStatusId"]);
                // book.Address = dt.Rows[i]["Address"].ToString();

                bookotherList.Add(book1);
            }
            return bookotherList;
        }
        
        public string UpdateBook(tbl_Book book)
        {
            string res = string.Empty;
            BookDetailDAL bl = new BookDetailDAL();
            string query = "update tblBooks set Name='" + book.Name + "',IsBn='" + book.IsBn + "',Price='"+book.Price+ "',Auther='"+book.Auther+ "',Publisher='"+book.Publisher+ "',Publisheddate='"+book.Publisheddate+ "',Description='"+book.Description+ "',Language='" + book.Language + "' where BookId='" + book.BookId+"'";
            bool flag = bl.DMLOpperation(query);
            if(flag)
            {
                res = "updated successfully";
            }
            {
                res = "failied to updated";
            }

            return res;
        }
        public List<tbl_Book> GetAllBookDetails(int userId)
        {
            BookDetailDAL bl = new BookDetailDAL();
            string query = "select BookId,Name,Price,IsBn,Auther,Publisher,Publisheddate,Description,Language,OrderStatusId from tblBooks where UserId='" + userId + "' ";
            DataTable dt = bl.SelactAll(query);

            List<tbl_Book> bookList = new List<tbl_Book>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tbl_Book book = new tbl_Book();
                book.BookId = (int)dt.Rows[i]["BookId"];
                book.Name = dt.Rows[i]["Name"].ToString();
                //book.Email = dt.Rows[i]["Email"].ToString();
                book.Price = Convert.ToDecimal(dt.Rows[i]["Price"]);
                book.IsBn = Convert.ToString(dt.Rows[i]["IsBn"]);
                book.Auther = Convert.ToString(dt.Rows[i]["Auther"]);
                book.Publisher = Convert.ToString(dt.Rows[i]["Publisher"]);
                book.Publisheddate = DateTime.Parse((dt.Rows[i]["Publisheddate"].ToString())).ToString("dd/MM/yyyy");//Convert.ToDateTime(dt.Rows[i]["Publisheddate"]);
                book.Description = Convert.ToString(dt.Rows[i]["Description"]);
                book.StatusInfo = Convert.ToInt32(dt.Rows[i]["OrderStatusId"]);
                // book.Address = dt.Rows[i]["Address"].ToString();

                bookList.Add(book);
            }
            return bookList;
        }

        public string DeleteBook(int BookId,int UserId)
        {
            string res = string.Empty;
            BookDetailDAL bl = new BookDetailDAL();
            //string query = "delete from  tblBooks where BookId='" + BookId + "'";
            string query = "SP_DellBooks";
            bool flag = bl.ProcedureOperation(query, BookId, UserId);
            if (flag)
            {
                res = "deleted successfully";
            }
            {
                res = "failied to delete";
            }

            return res;
        }
    }
}
