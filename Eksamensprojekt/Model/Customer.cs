using Model.BaseTypes;

namespace Model
{
    public class Customer : IBaseCustomer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CVRNumber { get; set; }
        public string CustomerAddress { get; set; }
        public int CustomerZip { get; set; }
        public string CustomerCity { get; set; }
        public int PhoneNo { get; set; }
        public string Email { get; set; }
        public double CustomerDiscount { get; set; }
        public string CustomerCountry { get; set; }
        
    }
}
