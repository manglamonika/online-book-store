using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBusinessLayer
{
   public class tbl_Users
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string Name { get; set; }
        //public string Address { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public int RoleId { get; set; }
        public bool IsAdmin { get; set; }
    }
}
