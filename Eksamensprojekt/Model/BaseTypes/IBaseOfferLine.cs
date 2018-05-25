namespace Model.BaseTypes
{
    public interface IBaseOfferLine
    {
        event APropertyWasChanged APWC;
        int OfferLineId { get; set; }
        IBaseItem Item { get; set; }
        int Quantity { get; set; }
        double DiscountedPrice { get; set; }
        double OfferLineTotal { get;}
        int NoOfPackages { get;}
        int NoOfPallets { get;}
    }
}
