using System;
using System.Collections.ObjectModel;

namespace Model.BaseTypes
{
    public interface IBaseOffer
    {
        int? OfferNo { get; set; }
        IBaseCustomer MyCustomer { get; set; }
        ObservableCollection<IBaseOfferLine> OfferLines { get; set; }
        double OfferDiscountPercent { get; set; }
        DateTime OfferCreationDate { get; set; }
        double ForwardingAgentPrice { get; set; }
        double OfferSubTotal { get; }
        double OfferTotal { get;  }
        string TotalDiscountedPrice { get; }
        string TotalPercentDiscount { get; }
        void Clear();
        void RemoveOfferLine(IBaseOfferLine offerLine);
    }
}
