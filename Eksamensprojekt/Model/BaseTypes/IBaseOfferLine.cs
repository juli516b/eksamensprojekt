namespace Model.BaseTypes
{
    public interface IBaseOfferLine
    {
        int OfferLineId { get; set; }
        int Quantity { get; set; }
        double DiscountedPrice { get; set; }
    }
}
