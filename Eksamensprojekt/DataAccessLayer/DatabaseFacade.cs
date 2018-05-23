using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using Model;
using Model.BaseTypes;
using DataAccessLayer.DataHandlers;

namespace DataAccessLayer
{
    public class DatabaseFacade : IPersistentItemDataHandler, IPersistentCustomerDataHandler
    {
        private static string connectionString = "Server = EALSQL1.eal.local; Database = DB2017_C13; User Id = USER_C13; Password = SesamLukOp_13";

        //try catch i ViewModel?
        public IList<IBaseItem> GetAll(IList<IBaseItem> items) //skal renames?
        {
            IList<IBaseItem> itemList = new List<IBaseItem>(); 
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
                        itemList.Add(newItem);
                    }
                }
            }
            return itemList;
        }

        public ObservableCollection<IBaseCustomer> GetAllCustomers()
        {
            IList<IBaseCustomer> customerList = new ObservableCollection<IBaseCustomer>();
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand getCurrentCustomers = new SqlCommand("spGetCurrentCustomers", con);
                getCurrentCustomers.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = getCurrentCustomers.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string customerAddress = reader["CustomerAddress"].ToString();
                        string customerCity = reader["City"].ToString();
                        string customerCountry = reader["Country"].ToString();
                        string customerName = reader["CustomerName"].ToString();
                        string cvrNumber = reader["CVRNumber"].ToString();
                        string email = reader["CustomerEmail"].ToString();
                        int customerZip = (int)reader["ZipCode"];
                        int phoneNo = (int)reader["CustomerPhoneNo"];
                        double customerDiscount = (double)reader["CustomerDiscountPercent"];

                        IBaseCustomer newCustomer = new Customer
                        {
                            CustomerAddress = customerAddress,
                            CustomerCity = customerCity,
                            CustomerZip = customerZip,
                            CustomerCountry = customerCountry,
                            CustomerName = customerName,
                            CVRNumber = cvrNumber,
                            Email = email,
                            CustomerDiscount = customerDiscount,
                            PhoneNo = phoneNo,
                        };
                        customerList.Add(newCustomer);
                    }
                }
            }
            return (ObservableCollection<IBaseCustomer>)customerList;
        }
        public string SaveCustomer(IBaseCustomer newCustomer)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand saveCustomer = new SqlCommand("spInsertCustomer", con);
                saveCustomer.CommandType = CommandType.StoredProcedure;
                {
                    saveCustomer.Parameters.AddWithValue("@MyCustomerName", newCustomer.CustomerName);
                    saveCustomer.Parameters.AddWithValue("@MyCVRNumber", newCustomer.CVRNumber);
                    saveCustomer.Parameters.AddWithValue("@MyCustomerAddress", newCustomer.CustomerAddress);
                    saveCustomer.Parameters.AddWithValue("@MyCustomerZipCode", newCustomer.CustomerZip);
                    saveCustomer.Parameters.AddWithValue("@MyCustomerCity", newCustomer.CustomerCity);
                    saveCustomer.Parameters.AddWithValue("@MyCustomerPhoneNo", newCustomer.PhoneNo);
                    saveCustomer.Parameters.AddWithValue("@MyCustomerEmail", newCustomer.Email);
                    saveCustomer.Parameters.AddWithValue("@MyCustomerDiscountPercent", newCustomer.CustomerDiscount);
                    saveCustomer.Parameters.AddWithValue("@MyCustomerCountry", newCustomer.CustomerCountry);
                }
                saveCustomer.ExecuteNonQuery();
            }
            return "Kunde blev tilføjet.";
        }
    }
}
