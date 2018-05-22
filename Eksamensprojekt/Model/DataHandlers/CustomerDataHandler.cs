using System.Collections.Generic;
using Model.BaseTypes;

namespace Model.DataHandlers
{
    public class CustomerDataHandler : IPersistentCustomerDataHandler
    {
        public IList<IBaseCustomer> GetAll(IList<IBaseCustomer> customers)
        {
            customers.Add(new Customer
                {
                CustomerName = "Svensk SuperMarked Gruppan A/S",
                CustomerAdress = "Norgesvej 17",
                CustomerDiscount = 3,
                CustomerZip = 5000,
                CustomerCity = "Odense",
                CVRNumber = "$@!§&&",
                Email = "Britta@Ikrea.se.dk",
                PhoneNo = 12345678,
                CustomerCountry = "Sverige"
                }
            );
            customers.Add(new Customer
                {
                CustomerName = "Pommes Konkurrent IPS",
                CustomerAdress = "Norgesvej 18",
                CustomerDiscount = 1,
                CustomerZip = 2860,
                CustomerCity =  "Søborg",
                CVRNumber = "8dk",
                Email = "nulle@pommes.dk",
                PhoneNo = 23456789,
                CustomerCountry = "Jylland"
                }
            );
            customers.Add(new Customer
                {
                CustomerName = "Grøntsager APS",
                CustomerAdress = "Norgesvej 19",
                CustomerDiscount = 9,
                CustomerZip = 90210,
                CustomerCity = "Beverly Hills",
                CVRNumber = "6",
                Email = "Gert@greens.dk",
                PhoneNo = 34567890,
                CustomerCountry = "Danmark"
                }
            );
            return customers;
        }
    }
}
