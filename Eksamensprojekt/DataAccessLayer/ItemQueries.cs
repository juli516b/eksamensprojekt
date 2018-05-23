using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using Model;
using Model.BaseTypes;
using Model.DataHandlers;

namespace DataAccessLayer
{
    public class ItemQueries : IPersistentItemDataHandler
    {
        private static string connectionString = "Server = EALSQL1.eal.local; Database = DB2017_C13; User Id = USER_C13; Password = SesamLukOp_13";

        //try catch i ViewModel
        public IList<IBaseItem> GetAll(IList<IBaseItem> items)
        {
            IList<IBaseItem> ItemList = new List<IBaseItem>(); 
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
                        string itemName = reader["ItemName"].ToString();
                        string itemNo = reader["ItemNo"].ToString();
                        double itemPrice = (double) reader["ItemPrice"];
                        double itemWeight = (double) reader["ItemWeight"];
                        int countPerPallet = (int) reader["ItemCountPerPallet"];

                        IBaseItem newItem = new Item(itemName, itemNo, itemPrice, itemWeight, countPerPallet);
                        ItemList.Add(newItem);
                    }
                }
            }
            return ItemList;
        }
    }
}
