using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBusinessLayer
{
    public class tbl_Book
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }

        //public string Email { get; set; }
        //public string Address { get; set; }
        public string IsBn { get; set; }
        public string Auther { get; set; }
        public string Publisher { get; set; }
        public string Publisheddate { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public int StatusInfo { get; set; }

        
    }
}
