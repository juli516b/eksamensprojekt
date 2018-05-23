namespace Model.BaseTypes
{
    public interface IBaseCustomer
    {
        int CustomerId { get; set; }
        string CustomerName { get; set; }
        string CVRNumber { get; set; }
        string CustomerAdress { get; set; }
        int CustomerZip { get; set; }
        string CustomerCity { get; set; }
        int PhoneNo { get; set; }
        string Email { get; set; }
        double CustomerDiscount { get; set; }
        string CustomerCountry { get; set; }
    }
}