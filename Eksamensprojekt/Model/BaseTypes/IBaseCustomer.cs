namespace Model
{
    public interface IBaseCustomer
    {
        string CustomerName { get; set; }
        string CVRNumber { get; set; }
        string CustomerAdress { get; set; }
        int CustomerZip { get; set; }
        int PhoneNo { get; set; }
        string Email { get; set; }
        double CustomerDiscount { get; set; }
    }
}