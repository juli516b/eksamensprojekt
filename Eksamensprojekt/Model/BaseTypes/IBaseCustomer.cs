namespace Model.BaseTypes
{
    public interface IBaseCustomer
    {
        int CustomerId { get; set; }
        string CustomerName { get; set; }
        string CVRNumber { get; set; }
        string CustomerAddress { get; set; }
        int CustomerZip { get; set; }
        string CustomerCity { get; set; }
        string CustomerCountry { get; set; }
        int PhoneNo { get; set; }
        string Email { get; set; }
        double CustomerDiscountPercent { get; set; }
    }
}