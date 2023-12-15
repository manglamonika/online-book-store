using BookDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBusinessLayer
{
   public class RegistrationService
    {
        public RegistrationService()
        {

        }

        public bool AddUsers(tbl_Users user)
        {
            BookDetailDAL bl = new BookDetailDAL();
            string query = "insert into tblUsers(Email,Password,Name,Mobile,Address,RoleId,IsAdmin) values('" + user.Email + "','" + user.Password + "','" + user.Name + "','" + user.Mobile + "','" + user.Address + "',2,0)";
            bool flag = bl.DMLOpperation(query);
            return flag;
        }
    }
}
