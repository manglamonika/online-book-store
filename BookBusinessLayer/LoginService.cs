using BookDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBusinessLayer
{
   public class LoginService
    {
        public LoginService()
        {

        }

        public DataTable Login(tblloginUser user)
        {
            BookDetailDAL bl = new BookDetailDAL();
            string query = "select Name,UserId,IsAdmin from tblUsers where Email='" + user.Email+ "' and Password='" + user.Password+"'";
            DataTable dt = bl.SelactAll(query);


            return dt;
        }
    }
}
