﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CustomerDataHandler : IPersistentCustomerDataHandler
    {
        public IList<IBaseCustomer> GetAll(IList<IBaseCustomer> customers)
        {
            customers.Add(new Customer()
            {
                CustomerName = "Svensk SuperMarked Gruppan A/S",
                CustomerAdress = "Norgesvej 17",
                CustomerDiscount = 3,
                CustomerZip = 5000,
                CVRNumber = "$@!§&&",
                Email = "Britta@Ikrea.se.dk",
                PhoneNo = 12345678
            }
            );
            customers.Add(new Customer()
            {
                CustomerName = "Pommes Konkurrent IPS",
                CustomerAdress = "Norgesvej 18",
                CustomerDiscount = 1,
                CustomerZip = 5003,
                CVRNumber = "8dk",
                Email = "nulle@pommes.dk",
                PhoneNo = 23456789
            }
);
            customers.Add(new Customer()
            {
                CustomerName = "Grøntsager APS",
                CustomerAdress = "Norgesvej 19",
                CustomerDiscount = 9,
                CustomerZip = 9000,
                CVRNumber = "6",
                Email = "Gert@greens.dk",
                PhoneNo = 34567890
            }
);
            return customers;
        }
    }
}
