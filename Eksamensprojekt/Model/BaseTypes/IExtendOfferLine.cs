namespace Model.BaseTypes
{
    public interface IExtendOfferLine : IBaseOfferLine
    {
        event APropertyWasChanged APWC;
        double OfferLineTotal { get;}
        int NoOfPackages { get;}
        int NoOfPallets { get;}
    }
}
