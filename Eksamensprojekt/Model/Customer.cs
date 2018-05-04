using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Customer : IBaseCustomer
    {
        public string CustomerName { get; set; }
        public string CVRNumber { get; set; }
        public string CustomerAdress { get; set; }
        public int CustomerZip { get; set; }
        public int PhoneNo { get; set; }
        public string Email { get; set; }
        public double CustomerDiscount { get; set; }
    }
}
