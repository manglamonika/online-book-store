using BookDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBusinessLayer
{
   public class UserService
    {
        public UserService()
        {

        }

        public bool AddUser(tbl_Users user)
        {
            BookDetailDAL bl = new BookDetailDAL();
            string query = "insert into tblUsers(Email,Password,Name,Mobile,Address,BankName,AccountNo,AccountHoldername,IfcsCode,RoleId,IsAdmin) values('" + user.Email + "','" + user.Password + "','" + user.Name + "','" + user.Mobile + "','" + user.Address + "',2,0)";
            bool flag = bl.DMLOpperation(query);
            return flag;
        }

        public string UpdateUser(tbl_Users user)
        {
            string res = string.Empty;
            BookDetailDAL bl = new BookDetailDAL();
            string query = "update tblUsers set Email='" + user.Email + "',Password='" + user.Password + "',Name='" + user.Name + "',Mobile='" + user.Mobile + "',Address='" + user.Mobile + "' where UserId='" + user.UserId + "'";
            bool flag = bl.DMLOpperation(query);
            if (flag)
            {
                res = "updated successfully";
            }
            {
                res = "failied to updated";
            }

            return res;
        }
        public List<tbl_Users> GetAllUserDetails()
        {
            BookDetailDAL bl = new BookDetailDAL();
            string query = "select UserId,Name,Email,Password,Mobile,Address from tblUsers";
            DataTable dt = bl.SelactAll(query);

            List<tbl_Users> userList = new List<tbl_Users>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tbl_Users user = new tbl_Users();
                user.UserId = (int)dt.Rows[i]["UserId"];
                user.Name = dt.Rows[i]["Name"].ToString();
                user.Email = dt.Rows[i]["Email"].ToString();
                user.Password = dt.Rows[i]["Password"].ToString();
                user.Mobile = Convert.ToString(dt.Rows[i]["Mobile"]);
                user.Address = Convert.ToString(dt.Rows[i]["Address"]);
                
                // book.Address = dt.Rows[i]["Address"].ToString();

                userList.Add(user);
            }
            return userList;
        }

        public string DeleteUser(int? UserId)
        {
            string res = string.Empty;
            BookDetailDAL bl = new BookDetailDAL();
            string query = "delete from  tblUsers where UserId='" + UserId + "'";
            bool flag = bl.DMLOpperation(query);
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
