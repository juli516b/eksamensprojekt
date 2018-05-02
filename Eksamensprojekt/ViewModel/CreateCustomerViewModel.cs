using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public class CreateCustomerViewModel
    {
        private Customer myCustomer;
        public event PropertyChangedEventHandler PropertyChanged;
        public string CustomerName
        {
            get {
                return myCustomer.CustomerName;
            }
            set {
                myCustomer.CustomerName = value;
            }
        }
        public string CVRNumber
        {
            get
            {
                return myCustomer.CVRNumber;
            }
            set
            {
                myCustomer.CVRNumber = value;
            }
        }
        public string CustomerAdress
        {
            get
            {
                return myCustomer.CustomerAdress;
            }
            set
            {
                myCustomer.CustomerAdress = value;
            }
        }
        public int CustomerZip
        {
            get
            {
                return myCustomer.CustomerZip;
            }
            set
            {
                myCustomer.CustomerZip = value;
            }
        }
        public int PhoneNo
        {
            get
            {
                return myCustomer.PhoneNo;
            }
            set
            {
                myCustomer.PhoneNo = value;
            }
        }
        public string Email
        {
            get
            {
                return myCustomer.Email;
            }
            set
            {
                myCustomer.Email = value;
            }
        }
        public double CustomerDiscount
        {
            get
            {
                return myCustomer.CustomerDiscount;
            }
            set
            {
                myCustomer.CustomerDiscount = value;
            }
        }

    }
}
