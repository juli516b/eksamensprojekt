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
        public ObservableCollection<IBaseCustomer> Customers { get; set; }
        public ObservableCollection<IBaseItem> Items { get; set; }
        //try catch i ViewModel?
        public ObservableCollection<IBaseItem> GetAllItems() 
        {
            ObservableCollection<IBaseItem> itemList = new ObservableCollection<IBaseItem>(); 
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
                        IBaseCustomer newCustomer = new Customer
                        {
                            CustomerId = (int)reader["Id"],
                            CustomerAddress = reader["CustomerAddress"].ToString(),
                            CustomerCity = reader["City"].ToString(),
                            CustomerCountry = reader["Country"].ToString(),
                            CustomerName = reader["CustomerName"].ToString(),
                            CVRNumber = reader["CVRNumber"].ToString(),
                            Email = reader["CustomerEmail"].ToString(),
                            CustomerZip = (int)reader["ZipCode"],
                            PhoneNo = (int)reader["CustomerPhoneNo"],
                            CustomerDiscountPercent = (double)reader["CustomerDiscountPercent"]
                        };
                        customerList.Add(newCustomer);
                    }
                }
            }
            return (ObservableCollection<IBaseCustomer>)customerList;
        }
        public IBaseCustomer SaveCustomer(IBaseCustomer newCustomer)
        {
            if (Customers == null)
            {
                Customers = new ObservableCollection<IBaseCustomer>();
            }
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
                    saveCustomer.Parameters.AddWithValue("@MyCustomerDiscountPercent", newCustomer.CustomerDiscountPercent);
                    saveCustomer.Parameters.AddWithValue("@MyCustomerCountry", newCustomer.CustomerCountry);
                }
                SqlDataReader reader = saveCustomer.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        newCustomer.CustomerId = int.Parse(reader["Id"].ToString());
                    }
                }
                if (!Customers.Contains(newCustomer))
                {
                    Customers.Add(newCustomer);
                }
            }
            return newCustomer;
        }
    }
}
