using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDAL
{
  public  class BookDetailDAL
    {

        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        public static SqlConnection connect()
        {
            string connection = ConfigurationManager.ConnectionStrings["Connect"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            else con.Open();
            return con;
        }


        public bool DMLOpperation(string query)
        {
            cmd = new SqlCommand(query, BookDetailDAL.connect());
            int x = cmd.ExecuteNonQuery();
            if (x == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ProcedureOperation(string query,int bookId, int UserId)
        {
            cmd = new SqlCommand(query, BookDetailDAL.connect());
           
                
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@BookId", SqlDbType.VarChar).Value = bookId;
                    cmd.Parameters.Add("@UserId", SqlDbType.VarChar).Value = UserId;
            int x =  cmd.ExecuteNonQuery();
             
            if (x == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public DataTable SelactAll(string query)
        {
            da = new SqlDataAdapter(query, BookDetailDAL.connect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
