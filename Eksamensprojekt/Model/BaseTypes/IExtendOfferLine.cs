namespace Model.BaseTypes
{
    public interface IExtendOfferLine : IBaseOfferLine
    {
        event APropertyWasChanged APWC;
        double OfferLineTotal { get;}
        double PercentDiscount { get; set; }
        int NoOfPackages { get;}
        int NoOfPallets { get;}
    }
}
