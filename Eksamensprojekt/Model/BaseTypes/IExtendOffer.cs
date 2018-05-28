using System;
using System.Collections.ObjectModel;

namespace Model.BaseTypes
{
    public interface IExtendOffer : IBaseOffer
    {
        double OfferSubTotal { get; }
        double OfferTotal { get; }
        string TotalDiscountedPrice { get; }
        string TotalPercentDiscount { get; }
        void Clear();
        void RemoveOfferLine(IExtendOfferLine offerLine);
    }
}
