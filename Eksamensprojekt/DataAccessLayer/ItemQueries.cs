using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace DataAccessLayer
{
    public class ItemQueries
    {
        private static string connectionString = "Server = EALSQL1.eal.local; Database = DB2017_C13; User Id = USER_C13; Password = SesamLukOp_13";

        //try catch i ViewModel
        public void GetCurrentItems()
        {
            string result = "";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand getCurrentItems = new SqlCommand("spGetCurrentItems", con);
                getCurrentItems.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = getCurrentItems.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        result = reader["ItemNo"].ToString();
                    }
                }
            }
        }
    }
}
